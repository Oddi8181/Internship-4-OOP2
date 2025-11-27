using Microsoft.EntityFrameworkCore;
using UserApp.Domain.Enteties.Users;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Infrastructure.Persistance
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly CompanyContext _ctx;
        public CompanyRepository(CompanyContext ctx)
        {
            _ctx = ctx;
        }

        public async Task DeactivateAsync(int id)
        {
            var c = await _ctx.Companies.FindAsync(id);
            if (c != null)
            {
                
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var c = await _ctx.Companies.FindAsync(id);
            if (c != null)
            {
                _ctx.Companies.Remove(c);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _ctx.Companies.ToListAsync();
        }

        public async Task<Company?> GetById(int id)
        {
            return await _ctx.Companies.FindAsync(id);
        }

        public async Task<Company> GetCompanyByName(object name)
        {
            var company = await _ctx.Companies.FirstOrDefaultAsync(c => c.Name == (string)name);
            if (company == null)
            {
                throw new InvalidOperationException($"Company with name '{name}' not found.");
            }
            return company;
        }

        public async Task InsertAsync(Company company)
        {
            _ctx.Companies.Add(company);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _ctx.Companies.Update(company);
            await _ctx.SaveChangesAsync();
        }
    }
}
