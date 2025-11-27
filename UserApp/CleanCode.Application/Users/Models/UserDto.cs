using UserApp.Domain.Enteties.Users;

namespace UserApp.Application.Users.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }
        public bool IsActive { get; set; }
        public string Phone { get; set; }
        public static UserDto From(User user)
        {
            if (user == null) return null;
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Website = user.Website,
                Company = user.Company,
                IsActive = user.IsActive,
                Phone = user.Phone
            };
        }
    }
}