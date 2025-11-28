using UserApp.Application.Common.Model;
using UserApp.Application.Common.Validation;
using UserApp.Application.Common.Validation.ValidationItems;
using UserApp.Application.Companies.Models;
using UserApp.Application.Companies.Queries.GetCompanyById;
using UserApp.Domain.Persistance.Users;
namespace UserApp.Application.Companies.Queries.GetCompanyById
    {
        public class GetCompanyByIdHandler
{
    private readonly ICompanyRepository _companies;
    private readonly IUserRepository _users;

    public GetCompanyByIdHandler(ICompanyRepository companies, IUserRepository users)
    {
        _companies = companies;
        _users = users;
    }

    public async Task<Result<CompanyDto>> HandleAsync(GetCompanyByIdQuery query)
    {
        var validation = new ValidationResult();

        if (!await UserAuthHelper.Authenticate(_users, query.Username, query.Password, validation))
            return Result<CompanyDto>.Fail(validation);

        var company = await _companies.GetById(query.Id);

        if (company == null)
        {
            validation.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Warning,
                Message = "Company not found."
            });
            return Result<CompanyDto>.Fail(validation);
        }

        return Result<CompanyDto>.Ok(CompanyDto.From(company));
    }
}

    }

