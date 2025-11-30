

namespace UserApp.Domain.Enteties.Users
{

    public class Geo
    {
        public int Id { get; set; }     

        public decimal Lat { get; set; }
        public decimal Lng { get; set; }

        public Geo() { }

        public Geo(decimal lat, decimal lng)
        {
            Lat = lat;
            Lng = lng;
        }
    }

    public class Address
    {
        public int Id { get; set; }     

        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        public int GeoId { get; set; }   
        public Geo Geo { get; set; }

        public Address() { }

        public Address(string street, string suite, string city, string zipcode, Geo geo)
        {
            Street = street;
            Suite = suite;
            City = city;
            Zipcode = zipcode;
            Geo = geo;
        }
    }

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }

        public string Phone { get; set; }
        public string? Website { get; set; }

        public string? Password { get; private set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get;  set; } = true;

        public int CompanyId { get; set; }      
        public Company Company { get; set; }

        public int? ExternalId { get; set; }

        public User() { }

        public User(string name, string username, string email, Address address, int companyId, string phone, string website, int? externalId)
        {
            Name = name;
            Username = username;
            Email = email;
            Address = address;
            CompanyId = companyId;
            Phone = phone;
            Website = website;
            ExternalId = externalId;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
