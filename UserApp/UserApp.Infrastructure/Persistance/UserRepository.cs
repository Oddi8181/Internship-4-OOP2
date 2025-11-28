using Microsoft.EntityFrameworkCore;
using UserApp.Domain.Enteties.Users;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext _ctx;

        public UserRepository(UsersContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<User?> GetByUsername(string username)
        {
            return await _ctx.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByCredentials(string username, string password)
        {
            return await _ctx.Users.FirstOrDefaultAsync(
                u => u.Username == username && u.Password == password
            );
        }

        public async Task DeactivateAsync(int id)
        {
            var user = await _ctx.Users.FindAsync(id);
            if (user != null)
            {
                user.Deactivate();
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var u = await _ctx.Users.FindAsync(id);
            if(u != null)
            {
                _ctx.Users.Remove(u);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task<bool> EmailExists(string mail)
        {
            return await _ctx.Users.AnyAsync(u => u.Email == mail);
        }

        public async Task<bool> ExternalIdExists(int externalId)
        {
            return await _ctx.Users.AnyAsync(u => u.ExternalId == externalId);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _ctx.Users
                .Include(u => u.Address)
                .ThenInclude(a => a.Geo)
                .Include(u => u.Company)
                .ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _ctx.Users
                .Include(u => u.Address)
                .ThenInclude(a => a.Geo)
                .Include(u => u.Company)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task InsertAsync(User user)
        {
            if(user.Address != null)
            {
                if(user.Address.Geo != null && user.Address.Geo.Id == 0)
                    _ctx.Geos.Add(user.Address.Geo);
                if(user.Address.Id == 0)
                    _ctx.Addresses.Add(user.Address);
                user.CreatedAt = DateTime.UtcNow;
            }
            
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> UsernameExists(string username)
        {
            return await _ctx.Users.AnyAsync(u => u.Username == username);
        }
    }
}
