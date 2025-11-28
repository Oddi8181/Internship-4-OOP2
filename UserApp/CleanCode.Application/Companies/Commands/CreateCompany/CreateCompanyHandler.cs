using UserApp.Application.Common.Model;
using UserApp.Application.Companies.Models;
using UserApp.Domain.Enteties.Users;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyHandler
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly CreateCompanyValidator _validator;

        public CreateCompanyHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
            _validator = new CreateCompanyValidator(companyRepository);
        }

        public async Task<Result<CompanyDto>> HandleAsync(CreateCompanyCommand cmd)
        {
            var validation = await _validator.ValidateAsync(cmd);
            if (validation.HasErrors)
                return Result<CompanyDto>.Fail(validation);
            var company = new Company(cmd.Name, cmd.CatchPhrase, cmd.Bs);
            await _companyRepository.InsertAsync(company);
            return Result<CompanyDto>.Ok(CompanyDto.From(company));
        }
    }
}
