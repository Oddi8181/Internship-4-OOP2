using System.Text.Json.Serialization;

namespace UserApp.Domain.Enteties.Users
{
    public class Company
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("catchPhrase")]
        public string CatchPhraze { get; set; }
        [JsonPropertyName("bs")]
        public string Bs { get; set; }

        public Company() { }
    }
}
