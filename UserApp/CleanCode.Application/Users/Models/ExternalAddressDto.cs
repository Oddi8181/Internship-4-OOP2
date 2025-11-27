namespace UserApp.Application.Users.Models
{
    public class ExternalAddressDto
    {
        
            public string Street { get; set; }
            public string Suite { get; set; }
            public string City { get; set; }
            public string Zipcode { get; set; }
            public ExternalGeoDto Geo { get; set; }
      
    }
}