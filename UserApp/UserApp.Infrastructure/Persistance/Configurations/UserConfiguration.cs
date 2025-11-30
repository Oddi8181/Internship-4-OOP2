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

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("id");

            builder.Property(u => u.Name).HasColumnName("name");
            builder.Property(u => u.Username).HasColumnName("username");
            builder.Property(u => u.Email).HasColumnName("email");
            builder.Property(u => u.Phone).HasColumnName("phone");
            builder.Property(u => u.Website).HasColumnName("website");
            builder.Property(u => u.Password).HasColumnName("password");
            builder.Property(u => u.CreatedAt).HasColumnName("created_at");
            builder.Property(u => u.IsActive).HasColumnName("is_active");

            builder.Property(u => u.CompanyId).HasColumnName("company_id");
            builder.Property(u => u.AddressId).HasColumnName("address_id");
            builder.Property(u => u.ExternalId).HasColumnName("external_id");
            builder.Property(u => u.DateOfBirth).HasColumnName("date_of_birth");

            builder.HasOne(u => u.Address)
                .WithMany()
                .HasForeignKey(u => u.AddressId);

            builder.HasOne(u => u.Company)
                .WithMany()
                .HasForeignKey(u => u.CompanyId);
        }
    }

}
