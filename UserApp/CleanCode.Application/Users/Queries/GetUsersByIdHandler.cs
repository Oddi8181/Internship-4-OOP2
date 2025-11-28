
using UserApp.Application.Common.Model;
using UserApp.Application.Common.Validation.ValidationItems;
using UserApp.Application.Users.Models;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Users.Queries
{
    public class GetUserByIdQuery
    {
        public int Id { get; set; }
    }
    public class GetUserByIdHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserDto>> HandleAsync(GetUserByIdQuery query)
        {
            var user = await _userRepository.GetById(query.Id);

            if (user == null)
            {
                var validation = new ValidationResult();
                validation.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = Common.Validation.ValidationSeverity.Error,
                    Message = "User je null."
                });

                return Result<UserDto>.Fail(validation);
            }

            return Result<UserDto>.Ok(UserDto.From(user));
        }
    }
}
