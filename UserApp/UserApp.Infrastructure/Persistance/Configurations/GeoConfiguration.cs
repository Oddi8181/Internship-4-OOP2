using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserApp.Domain.Enteties.Users;

namespace UserApp.Infrastructure.Persistance.Configurations
{
    public class GeoConfiguration : IEntityTypeConfiguration<Geo>
    {
        public void Configure(EntityTypeBuilder<Geo> builder)
        {
            builder.ToTable("geo");

            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id).HasColumnName("id");

            builder.Property(g => g.Lat)
                .HasColumnName("lat")
                .IsRequired();

            builder.Property(g => g.Lng)
                .HasColumnName("lng")
                .IsRequired();
        }
    }
}
