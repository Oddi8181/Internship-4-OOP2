

using UserApp.Domain.Enteties.Users;

namespace UserApp.Domain.Persistance.Users
{
    public interface ICompanyRepository
    {
        Task<Company> GetById(int id);
        Task InsertAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(int id);
        Task DeactivateAsync(int id);
        Task<IEnumerable<Company>> GetAllCompanies();
    }
}
