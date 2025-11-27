

namespace UserApp.Application.Users.Models;

public interface IExternalUserService
{
 
    Task<ExternalUserDto?> GetUser(int id);
}
