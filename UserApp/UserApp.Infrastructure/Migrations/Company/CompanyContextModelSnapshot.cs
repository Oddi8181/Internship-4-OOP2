using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using UserApp.Infrastructure.Persistance;

#nullable disable

namespace UserApp.Infrastructure.Migrations
{
    [DbContext(typeof(CompanyContext))]
    partial class CompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("UserApp.Domain.Enteties.Users.Company", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                b.Property<string>("Bs")
                    .HasMaxLength(255)
                    .HasColumnType("varchar(255)");

                b.Property<string>("CatchPhrase")
                    .HasMaxLength(255)
                    .HasColumnType("varchar(255)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnType("varchar(150)");

                b.HasKey("Id");
                b.ToTable("companies");
            });
        }
    }
}
