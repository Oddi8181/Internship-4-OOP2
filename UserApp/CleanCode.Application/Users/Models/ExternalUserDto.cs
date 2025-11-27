namespace UserApp.Application.Users.Models
{
    public class ExternalUserDto
    {
   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ExternalAddressDto Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public ExternalCompanyDto Company { get; set; }
        public int? ExternalId { get; set; }


    }
}
