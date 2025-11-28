using UserApp.Application.Common.Model;
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
        
        public async Task<Result<List<UserDto>>> Handle()
        {
            var users = await _userRepository.GetAllUsers();
            var dto = users.Select(UserDto.From).ToList();
            return Result<List<UserDto>>.Ok(dto);
        }
    }
}
