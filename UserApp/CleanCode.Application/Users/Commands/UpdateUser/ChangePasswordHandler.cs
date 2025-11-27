using UserApp.Application.Common.Model;
using UserApp.Application.Common.Validation;
using UserApp.Application.Common.Validation.ValidationItems;
using UserApp.Domain.Persistance.Users;


namespace UserApp.Application.Users.Commands.UpdateUser
{
    public class ChangePasswordHandler
    {
        private readonly IUserRepository _userRepository;
        public ChangePasswordHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<bool>> Handle(ChangePasswordCommand cmd)
        {
            var validation = new ValidationResult();
            if (string.IsNullOrWhiteSpace(cmd.NewPassword))
            {
                validation.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "Password cannot be empty."
                });
                return Result<bool>.Fail(validation);
            }
            var user = await _userRepository.GetById(cmd.UserId);
            if (user == null)
            {
                validation.AddValidationItem(new ValidationItem
                {
                    ValidationSeverity = ValidationSeverity.Error,
                    Message = "User with this id does not exist."
                });
                return Result<bool>.Fail(validation);
            }
           user.SetPassword(cmd.NewPassword);
            await _userRepository.UpdateAsync(user);
            return Result<bool>.Ok(true);
        }
    }
}
