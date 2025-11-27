using UserApp.Application.Users.Models;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Users.Queries
{
    public class GetAllUsersQuery
    {

    }
    public class GetAllUsersHandler
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<IEnumerable<UserDto>> Hadle()
        {
            var users = await _userRepository.GetAllUsers();
            return users.Select(UserDto.From);
        }
    }
}
