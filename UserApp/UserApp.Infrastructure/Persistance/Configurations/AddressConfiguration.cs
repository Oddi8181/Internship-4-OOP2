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
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Street).HasMaxLength(300);
            builder.Property(x => x.Suite).HasMaxLength(100);
            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.Zipcode).HasMaxLength(50);


            builder.HasOne(a => a.Geo)
            .WithMany()
            .HasForeignKey("GeoId")
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
