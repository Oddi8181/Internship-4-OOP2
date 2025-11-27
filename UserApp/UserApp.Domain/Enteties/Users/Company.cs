using System.Text.Json.Serialization;

namespace UserApp.Domain.Enteties.Users
{
    public class Company
    {


        public int Id { get; set; }

        public string Name { get; set; }
        public string CatchPhrase { get; set; }
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
