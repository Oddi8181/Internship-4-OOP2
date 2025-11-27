
using UserApp.Application.Common.Validation;
using UserApp.Application.Common.Validation.ValidationItems;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Users.Commands.ImportExternalUser
{
    public class ImportExternalUserValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;

        public ImportExternalUserValidator(IUserRepository userRepository, ICompanyRepository companyRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }
        public async Task<ValidationResult> ValidateAsync(ImportExternalUserCommand cmd)
        {
            var result = new ValidationResult();

            if(cmd.ExternalUserId <= 0)
            {
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Id must be larger than 0 or equal"
                });
                return result;
            }
            if (await _userRepository.ExternalIdExists(cmd.ExternalUserId))
            {
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "User already imported."
                });
            }

            return result;

        }

    }
}
