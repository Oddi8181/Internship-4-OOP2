using System.Security.Cryptography.X509Certificates;

namespace UserApp.Application.Companies.Queries.GetAllCompanies
{
    public class GetAllCompaniesQuery
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public GetAllCompaniesQuery()
        {
           
        }
    }
}
