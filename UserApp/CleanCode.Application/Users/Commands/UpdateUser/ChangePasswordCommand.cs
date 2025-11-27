namespace UserApp.Application.Users.Commands.UpdateUser
{
    public class ChangePasswordCommand
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
