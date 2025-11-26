using UserApp.Domain.Enteties.Users;

namespace UserApp.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public string? Website { get; set; }
        public Company Company { get; set; }

    }
}
