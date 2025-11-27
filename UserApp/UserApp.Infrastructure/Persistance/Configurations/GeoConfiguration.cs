using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserApp.Domain.Enteties.Users;

namespace UserApp.Infrastructure.Persistance.Configurations
{
    internal class GeoConfiguration : IEntityTypeConfiguration<Geo>
    {
        public void Configure(EntityTypeBuilder<Geo> builder)
        {
            builder.ToTable("geos");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Lat).HasColumnType("numeric(10,6)");
            builder.Property(x => x.Lng).HasColumnType("numeric(10,6)");
        }
    }
}
