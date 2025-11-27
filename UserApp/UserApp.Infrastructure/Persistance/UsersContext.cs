using Microsoft.EntityFrameworkCore;
using UserApp.Domain.Enteties.Users;
using UserApp.Infrastructure.Persistance.Configurations;

namespace UserApp.Infrastructure.Persistance
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Geo> Geos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new GeoConfiguration());
        }

    }
}
