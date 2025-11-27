using System.Text.Json.Serialization;

namespace UserApp.Domain.Enteties.Users
{
    public class Company
    {
        

        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("catchPhrase")]
        public string CatchPhrase { get; set; }
        [JsonPropertyName("bs")]
        public string Bs { get; set; }

        public Company() { }

        public Company(string name, string catchPhrase, string bs)
        {
            Name = name;
            CatchPhrase = catchPhrase;
            Bs = bs;
        }
    }
}
