using Microsoft.EntityFrameworkCore;
using UserApp.Domain.Enteties.Users;
using UserApp.Infrastructure.Persistance.Configurations;

namespace UserApp.Infrastructure.Persistance
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
            
        }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
    }
}
