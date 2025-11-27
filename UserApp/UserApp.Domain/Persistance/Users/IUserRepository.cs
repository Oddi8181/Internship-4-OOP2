

using UserApp.Domain.Enteties.Users;

namespace UserApp.Domain.Persistance.Users
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task InsertAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task DeactivateAsync(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> ExternalIdExists(int id);
        Task<bool> EmailExists(string mail);
        Task<bool> UsernameExists(string username);
    }
}
