using System.Text.Json.Serialization;

namespace UserApp.Domain.Enteties.Users
{

    public class Geo
    {
        [JsonPropertyName("lat")]
        public decimal Lat { get; set; }
        [JsonPropertyName("lng")]
        public decimal Lng { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("suite")]
        public string Suite { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }
        [JsonPropertyName("geo")]
        public Geo Geo { get; set; } = new Geo();
    }

    public class User
    {
        
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; } 

        public DateTime DateOfBirth { get; set; }
        [JsonPropertyName("address")]
        public Address Address { get; set; } = new Address();
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("website")]
        public string? Website { get; set; }
        public string Password { get; set; } 
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        [JsonPropertyName("company")]
        public Company Company { get; set; } = new Company();

        public User()
        {
            
        }
    }
}
