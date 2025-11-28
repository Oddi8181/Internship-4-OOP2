using UserApp.Application.Common.Validation.ValidationItems;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyValidator
    {
        private readonly ICompanyRepository _repo;
        public UpdateCompanyValidator(ICompanyRepository repo)
        {
            _repo = repo;
        }


        public async Task<ValidationResult> ValidateAsync(UpdateCompanyCommand cmd)
        {
            var result = new ValidationResult();
            var company = await _repo.GetById(cmd.Id);
            if (company == null)
                result.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = Common.Validation.ValidationSeverity.Error,
                    Message = "Company that you are trying to update does not exist."
                });


            return result;
        }
    }
}
