using Dapper;
using System.Data;
using UserApp.Domain.Enteties.Users;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Infrastructure.Persistance
{
    public class UserReadRepository : IUserReadRepository
    {
        private readonly IDbConnection _connection;

        public UserReadRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var sql = "SELECT * FROM users";
            return await _connection.QueryAsync<User>(sql);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM users WHERE id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }
    }
}
