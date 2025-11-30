using System.Text.Json;
using UserApp.Application.Users.Models;
using UserApp.Domain.Persistance.Users;

namespace UserApp.Infrastructure.Persistance.Configurations
{
    public class ExternalUserService : IExternalUserService
    {
        private readonly HttpClient _httpClient;
        private readonly ICacheService _cache;
        private const string CacheKeyAll = "external_users_all";
        public ExternalUserService(HttpClient http)
        {
            _httpClient = http;
        }
        public async Task<ExternalUserDto?> GetUser(int id)
        {
            var resp = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{id}");
            if (!resp.IsSuccessStatusCode) return null;

            var json = await resp.Content.ReadAsStringAsync();
            var dto = JsonSerializer.Deserialize<ExternalUserDto>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return dto;
        }
        public async Task<IReadOnlyList<ExternalUserDto>?> GetAllExternalUsers()
        {
            var cached = await _cache.GetAsync<List<ExternalUserDto>>(CacheKeyAll);
            if (cached != null)
                return cached;

            
            HttpResponseMessage resp;
            try
            {
                resp = await _httpClient.GetAsync("users");
            }
            catch
            {
                return null; 
            }

            if (!resp.IsSuccessStatusCode)
                return null;

            var json = await resp.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<ExternalUserDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (users != null)
            {
                await _cache.SetAsync(CacheKeyAll, users, MemoryCacheService.EndOfToday());
            }

            return users;
        }
    }
}
