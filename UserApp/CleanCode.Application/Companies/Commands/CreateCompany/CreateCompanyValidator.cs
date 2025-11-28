
using UserApp.Application.Common.Validation;
using UserApp.Application.Common.Validation.ValidationItems;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyValidator
    {
        private readonly ICompanyRepository _companyRepository;
        public CreateCompanyValidator(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ValidationResult> ValidateAsync(CreateCompanyCommand cmd)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(cmd.Name))
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Name is required."
                });
            var exists = await _companyRepository.GetCompanyByName(cmd.Name);
            if (exists != null)
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Company with same name already exists."
                });
            return result;
        }
    }
}
