

using UserApp.Application.Common.Model;
using UserApp.Application.Common.Validation;
using UserApp.Application.Common.Validation.ValidationItems;
using UserApp.Application.Users.Models;
using UserApp.Domain.Enteties.Users;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Users.Commands.ImportExternalUser
{
    internal class ImportExternalUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IExternalUserService _externalUserService;
        private readonly ICompanyRepository _companyRepository; 
        private readonly ImportExternalUserValidator _validator;

        public ImportExternalUserHandler(IUserRepository userRepository, 
            IExternalUserService externalUserService, 
            ICompanyRepository companyRepository)
        {
            _userRepository = userRepository;
            _externalUserService = externalUserService;
            _companyRepository = companyRepository;
            _validator = new ImportExternalUserValidator(_userRepository, _companyRepository);
        }
        public async Task<Result<UserDto>> Handle(ImportExternalUserCommand cmd)
        {
            var validation = await _validator.ValidateAsync(cmd);
            if (validation.HasErrors)
                return Result<UserDto>.Fail(validation);

            var external = await _externalUserService.GetUser(cmd.ExternalUserId);
            if (external == null)
            {
                var err = new ValidationResult();
                err.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Warning,
                    Message = "External user not found"
                });
                return Result<UserDto>.Fail(err);

            }

            if (await _userRepository.EmailExists(external.Email))
            {
                var err = new ValidationResult();
                err.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "User with this email already exists."
                });
                return Result<UserDto>.Fail(err);
            }
            if (await _userRepository.UsernameExists(external.Username))
            {
                var err = new ValidationResult();
                err.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "User with this username already exists."
                });
                return Result<UserDto>.Fail(err);
            }
            var geo = new Geo(
               decimal.Parse(external.Address.Geo.Lat, System.Globalization.CultureInfo.InvariantCulture),
               decimal.Parse(external.Address.Geo.Lng, System.Globalization.CultureInfo.InvariantCulture)
            );
            var address = new Address(
               external.Address.Street,
               external.Address.Suite,
               external.Address.City,
               external.Address.Zipcode,
               geo
           );
           

            var existingCompany = await _companyRepository.GetCompanyByName(external.Company.Name);
            int companyId;

            if (existingCompany != null)
            {
                companyId = existingCompany.Id;
            }
            else
            {
                var company = new Company(
                    external.Company.Name,
                    external.Company.CatchPhrase,
                    external.Company.Bs
                );

                await _companyRepository.InsertAsync(company);
                companyId = company.Id;
            }
            var user = new User(
                external.Name,
                external.Username,
                external.Email,
                address,
                companyId,
                external.Phone,
                external.Website
            );

            user.SetPassword(Guid.NewGuid().ToString());
            await _userRepository.InsertAsync(user);
            var dto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                Address = user.Address,
                Website = user.Website,
                Company = user.Company,
                IsActive = user.IsActive
            };

            return Result<UserDto>.Ok(dto);
        }
        
    }
}
