using UserApp.Application.Common.Model;
using UserApp.Application.Common.Validation;
using UserApp.Application.Common.Validation.ValidationItems;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Application.Users.Commands.UpdateUser
{
    public class DeactivateUserHandler
    {
        private readonly IUserRepository _userRepository;
        public DeactivateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<bool>> Handle(DeactivateUserCommand cmd)
        {
            var validation = new ValidationResult();
            var user = await _userRepository.GetById(cmd.Id);
            if (user == null)
            {
                validation.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "User not found"
                });
                return Result<bool>.Fail(validation);
            }
            user.Deactivate();
            await _userRepository.DeactivateAsync(cmd.Id);
            return Result<bool>.Ok(true);
        }
    }
}
