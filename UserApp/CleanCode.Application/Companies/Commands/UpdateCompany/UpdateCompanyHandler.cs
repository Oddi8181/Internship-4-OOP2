using UserApp.Application.Common.Model;
using UserApp.Application.Companies.Models;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyHandler
    {
        private readonly ICompanyRepository _repo;
        private readonly UpdateCompanyValidator _validator;

        public UpdateCompanyHandler(ICompanyRepository repo)
        {
            _repo = repo;
            _validator = new UpdateCompanyValidator(repo); 
        }
        public async Task<Result<CompanyDto>> HandleAsync(UpdateCompanyCommand cmd)
        {
            var validation = await _validator.ValidateAsync(cmd);
            if (validation.HasErrors)
                return Result<CompanyDto>.Fail(validation);
            var company = await _repo.GetById(cmd.Id);
            company.Name = cmd.Name;
            company.CatchPhrase = cmd.CatchPhrase;
            company.Bs = cmd.Bs;

            await _repo.UpdateAsync(company);
            return Result<CompanyDto>.Ok(CompanyDto.From(company));
        }
    }
}
