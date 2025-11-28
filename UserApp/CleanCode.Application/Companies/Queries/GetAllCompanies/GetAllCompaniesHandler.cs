using UserApp.Application.Common.Model;
using UserApp.Application.Common.Validation;
using UserApp.Application.Common.Validation.ValidationItems;
using UserApp.Application.Companies.Models;
using UserApp.Application.Companies.Queries.GetAllCompanies;
using UserApp.Domain.Persistance.Users;

public class GetAllCompaniesHandler
{
    private readonly ICompanyRepository _companies;
    private readonly IUserRepository _users;

    public GetAllCompaniesHandler(ICompanyRepository companies, IUserRepository users)
    {
        _companies = companies;
        _users = users;
    }

    public async Task<Result<List<CompanyDto>>> HandleAsync(GetAllCompaniesQuery query)
    {
        var validation = new ValidationResult();

        // auth
        if (!await UserAuthHelper.Authenticate(_users, query.Username, query.Password, validation))
            return Result<List<CompanyDto>>.Fail(validation);

        var companies = await _companies.GetAllCompanies();
        var dtos = companies.Select(c => CompanyDto.From(c)).ToList();

        return Result<List<CompanyDto>>.Ok(dtos);
    }
}
