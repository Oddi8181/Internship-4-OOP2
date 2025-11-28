using UserApp.Domain.Enteties.Users;

namespace UserApp.Application.Companies.Models
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }


        public static CompanyDto From(Company c)
        {
            return new CompanyDto
            {
                Id = c.Id,
                Name = c.Name,
                CatchPhrase = c.CatchPhrase,
                Bs = c.Bs
            };
        }
    }
}
