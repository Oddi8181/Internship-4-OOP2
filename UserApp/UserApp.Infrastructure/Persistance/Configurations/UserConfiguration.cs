using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserApp.Domain.Enteties.Users;

namespace UserApp.Infrastructure.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Phone).HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
           

            builder.HasOne(u => u.Address)
                .WithMany()
                .HasForeignKey("AddressId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.CompanyId).IsRequired();
        }
    }
}
