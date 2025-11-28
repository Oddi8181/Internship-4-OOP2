using UserApp.Domain.Enteties.Users;

namespace UserApp.Domain.Persistance.Users
{
    public interface IUserReadRepository
    {
        public Task<User?> GetByIdAsync(int id);
        public Task<IEnumerable<User>> GetAllAsync();

    }
}
