using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using UserApp.Infrastructure.Persistance;

#nullable disable

namespace UserApp.Infrastructure.Migrations
{
    [DbContext(typeof(UsersContext))]
    partial class UsersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("UserApp.Domain.Enteties.Users.Geo", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                b.Property<decimal?>("Lat")
                    .HasColumnType("numeric(10,6)");

                b.Property<decimal?>("Lng")
                    .HasColumnType("numeric(10,6)");

                b.HasKey("Id");
                b.ToTable("geos");
            });

            modelBuilder.Entity("UserApp.Domain.Enteties.Users.Address", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                b.Property<string>("City")
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                b.Property<int?>("GeoId")
                    .HasColumnType("integer");

                b.Property<string>("Street")
                    .HasMaxLength(300)
                    .HasColumnType("varchar(300)");

                b.Property<string>("Suite")
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                b.Property<string>("Zipcode")
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.HasKey("Id");
                b.HasIndex("GeoId");
                b.ToTable("addresses");
            });

            modelBuilder.Entity("UserApp.Domain.Enteties.Users.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer");

                b.Property<int?>("AddressId")
                    .HasColumnType("integer");

                b.Property<int>("CompanyId")
                    .HasColumnType("integer");

                b.Property<DateTime>("CreatedAt")
                    .HasColumnType("timestamp without time zone");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

                b.Property<bool>("IsActive")
                    .HasColumnType("boolean");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

                b.Property<string>("Password")
                    .HasMaxLength(500)
                    .HasColumnType("varchar(500)");

                b.Property<string>("Phone")
                    .HasMaxLength(50)
                    .HasColumnType("varchar(50)");

                b.Property<string>("Username")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                b.HasKey("Id");
                b.HasIndex("AddressId");
                b.ToTable("users");
            });
        }
    }
}
