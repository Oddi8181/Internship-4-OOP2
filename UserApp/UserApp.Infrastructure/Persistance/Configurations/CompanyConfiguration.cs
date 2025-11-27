using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserApp.Domain.Enteties.Users;

namespace UserApp.Infrastructure.Persistance.Configurations
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("companies");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.CatchPhrase).HasMaxLength(500);
            builder.Property(x => x.Bs).HasMaxLength(500);
        }
    }
}
