using UserApp.Application.Common.Validation;
using UserApp.Application.Common.Validation.ValidationItems;
using UserApp.Domain.Persistance.Users;

public static class UserAuthHelper
{
    public static async Task<bool> Authenticate(
        IUserRepository userRepo,
        string username,
        string password,
        ValidationResult validation)
    {
        var user = await userRepo.GetByCredentials(username, password);

        if (user == null)
        {
            validation.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Message = "Invalid username or password."
            });
            return false;
        }

        if (!user.IsActive)
        {
            validation.AddValidationItem(new ValidationItem
            {
                ValidationSeverity = ValidationSeverity.Error,
                Message = "User is not active."
            });
            return false;
        }

        return true;
    }
}
