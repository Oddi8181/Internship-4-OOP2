
using UserApp.Application.Common.Utils;
using UserApp.Application.Common.Validation;
using UserApp.Application.Common.Validation.ValidationItems;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Users.Commands.CreateUser
{
    public class CreateUserValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;

        public CreateUserValidator(IUserRepository users, ICompanyRepository companies)
        {
            _userRepository = users;
            _companyRepository = companies;
        }
        public async Task<ValidationResult> Validate(CreateUserCommand cmd)
        {
            var result = new ValidationResult();

            if (string.IsNullOrEmpty(cmd.Name))
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Name is requred."
                });

            if (cmd.Name.Length > 100)
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Name is too long."
                });
            if (!EmailUtils.IsValid(cmd.Email))
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Invalid email format."
                });
            var emailExists = await _userRepository.EmailExists(cmd.Email);
            if (emailExists)
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Email already exists."
                });
            var usernameExists = await _userRepository.UsernameExists(cmd.Username);
            if (usernameExists)
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Username is taken."
                });
            if (cmd.Address.Street.Length > 150)
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Addres name is too long."
                });

            if (string.IsNullOrEmpty(cmd.Address.Street))
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Street name is required"
                });
            if (cmd.Address.City.Length > 150)
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "City name is too long."
                });
            if (string.IsNullOrEmpty(cmd.Address.City))
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "City name is required"
                });
            if (cmd.Address.Geo.Lat < -90 || cmd.Address.Geo.Lat > 90)
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Latitude has to be between -90 and 90"
                });
            if (cmd.Address.Geo.Lng < -180 || cmd.Address.Geo.Lng > 180)
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Longitude has to be between -90 and 90"
                });

            if (string.IsNullOrEmpty(cmd.Address.Suite))
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Street name is required"
                });
            if (!ZipcodeUtils.IsValid(cmd.Address.Zipcode))
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Invalid zipcode format."
                });
            
            if (!string.IsNullOrEmpty(cmd.Website) && !URLUtils.IsValid(cmd.Website))
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "URL format is wrong."
                });
            
            if (!string.IsNullOrEmpty(cmd.Website) && cmd.Website.Length > 150)
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Website name is too long."
                });
            

            return result;
        }

    }
}
