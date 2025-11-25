namespace UserApp.Domain.Enteties.Users
{
    public class User
    {
        
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Username { get; set; } 
        public string Email { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public decimal GeoLat { get; set; }
        public decimal GeoLng { get; set; }
        public string Website { get; set; }
        public string password { get; set; } 
        public DateTime createdAt { get; set; }
        public bool IsActive { get; set; } = true;


        public User()
        {
            
        }
    }
}
