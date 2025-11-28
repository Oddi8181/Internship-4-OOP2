using System.ComponentModel.DataAnnotations;
using UserApp.Application.Common.Validation;
using UserApp.Application.Common.Validation.ValidationItems;
using UserApp.Domain.Enteties.Users;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyValidator
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyValidator(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Common.Validation.ValidationItems.ValidationResult> ValidateAsync(DeleteCompanyCommand cmd)
        {

            var result = new Common.Validation.ValidationItems.ValidationResult();
            var company = await _companyRepository.GetById(cmd.Id);
            if (company == null)
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Company does not exist."
                });
            return result;
        }
    }
}
