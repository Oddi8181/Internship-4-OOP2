using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using UserApp.Application.Users.Models;
using UserApp.Domain.Enteties.Users;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Infrastructure.Persistance
{
    public class UserReadRepository : IUserReadRepository
    {
        private readonly string _connectionString;
        public UserReadRepository(IConfiguration configuration)
        {
            var connStr = configuration.GetConnectionString("UserDb");
            if (connStr is null)
            {
                throw new InvalidOperationException("Connection string 'UserDb' not found.");
            }
            _connectionString = connStr;
        }
        private NpgsqlConnection GetConn() => new NpgsqlConnection(_connectionString);
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            await using var conn = GetConn();
            var sql = @"
SELECT u.id as Id, u.name as Name, u.username as Username, u.email as Email,
u.phone as Phone, u.website as Website, u.isactive as IsActive,
a.id as AddressId, a.street as Address_Street, a.suite as Address_Suite, a.city as Address_City, a.zipcode as Address_Zipcode,
g.lat as Address_Geo_Lat, g.lng as Address_Geo_Lng,
c.id as Company_Id, c.name as Company_Name, c.catchphrase as Company_CatchPhrase, c.bs as Company_Bs
FROM users u
LEFT JOIN addresses a ON a.id = u.addressid
LEFT JOIN geos g ON g.id = a.geoid
LEFT JOIN companies c ON c.id = u.companyid";


            var rows = await conn.QueryAsync<dynamic>(sql);
            var list = new List<User>();
            foreach (var row in rows)
            {
                var dto = new User
                {
                    Id = row.id,
                    Name = row.name,
                    Username = row.username,
                    Email = row.email,
                    Phone = row.phone,
                    Website = row.website,
                    IsActive = row.isactive,
                    Address = new Domain.Enteties.Users.Address
                    {
                        Id = row.addressid,
                        Street = row.address_street,
                        Suite = row.address_suite,
                        City = row.address_city,
                        Zipcode = row.address_zipcode,
                        Geo = new Domain.Enteties.Users.Geo
                        {
                            Id = 0,
                            Lat = row.address_geo_lat,
                            Lng = row.address_geo_lng
                        }
                    },
                    Company = row.company_id == null ? null : new Domain.Enteties.Users.Company
                    {
                        Id = row.company_id,
                        Name = row.company_name,
                        CatchPhrase = row.company_catchphrase,
                        Bs = row.company_bs
                    }
                };
                list.Add(dto);
            }
            return list;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            await using var conn = GetConn();
            var sql = @"
                SELECT u.id as Id, u.name as Name, u.username as Username, u.email as Email,
                u.phone as Phone, u.website as Website, u.isactive as IsActive,
                a.id as AddressId, a.street as Address_Street, a.suite as Address_Suite, a.city as Address_City, a.zipcode as Address_Zipcode,
                g.lat as Address_Geo_Lat, g.lng as Address_Geo_Lng,
                c.id as Company_Id, c.name as Company_Name, c.catchphrase as Company_CatchPhrase, c.bs as Company_Bs
                FROM users u
                LEFT JOIN addresses a ON a.id = u.addressid
                LEFT JOIN geos g ON g.id = a.geoid
                LEFT JOIN companies c ON c.id = u.companyid
                WHERE u.id = @Id";

            var result = await conn.QueryAsync<dynamic>(sql, new { Id = id });
            var row = result.FirstOrDefault();
            if (row == null) return null;
            var dto = new User
            {
                Id = row.id,
                Name = row.name,
                Username = row.username,
                Email = row.email,
                Phone = row.phone,
                Website = row.website,
                IsActive = row.isactive,
                Address = new Domain.Enteties.Users.Address
                {
                    Id = row.addressid,
                    Street = row.address_street,
                    Suite = row.address_suite,
                    City = row.address_city,
                    Zipcode = row.address_zipcode,
                    Geo = new Domain.Enteties.Users.Geo
                    {
                        Id = 0,
                        Lat = row.address_geo_lat,
                        Lng = row.address_geo_lng
                    }
                },
                Company = row.company_id == null ? null : new Company
                {
                    Id = row.company_id,
                    Name = row.company_name,
                    CatchPhrase = row.company_catchphrase,
                    Bs = row.company_bs
                }
            };
            return dto;
        }
    }
}
