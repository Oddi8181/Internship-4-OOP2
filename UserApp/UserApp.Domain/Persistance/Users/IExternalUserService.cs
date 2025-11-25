using UserApp.Domain.Enteties.Users;

namespace UserApp.Domain.Persistance.Users
{
    public interface IExternalUserService
    {
        Task<IEnumerable<User>> GetExternalUsers();
    }
}
