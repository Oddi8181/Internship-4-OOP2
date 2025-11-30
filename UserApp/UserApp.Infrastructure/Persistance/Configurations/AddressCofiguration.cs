using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserApp.Domain.Enteties.Users;

namespace UserApp.Infrastructure.Persistance.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("addresses");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("id");

            builder.Property(a => a.Street)
                .HasColumnName("street")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Suite)
                .HasColumnName("suite")
                .HasMaxLength(200);

            builder.Property(a => a.City)
                .HasColumnName("city")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Zipcode)
                .HasColumnName("zipcode")
                .HasMaxLength(50);

            builder.Property(a => a.GeoId)
                .HasColumnName("geo_id")
                .IsRequired();

            builder.HasOne(a => a.Geo)
                .WithMany()
                .HasForeignKey(a => a.GeoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
