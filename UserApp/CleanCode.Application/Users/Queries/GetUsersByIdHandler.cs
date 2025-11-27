using UserApp.Application.Users.Models;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Users.Queries
{
    public class GetUserByIdQuery
    {
        public int Id { get; set; }
    }
    public class GetUsersByIdHandler
    {
       
      
         private readonly IUserRepository _userRepository;

         public GetUsersByIdHandler(IUserRepository userRepository)
         {
             _userRepository = userRepository;
         }
         public async Task<UserDto?> HandleAsync(GetUserByIdQuery query)
         {
             var user = await _userRepository.GetById(query.Id);
             return user == null ? null : UserDto.From(user);
         }
      
    }
}
