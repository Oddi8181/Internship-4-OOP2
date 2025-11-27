using System.Text.Json;
using UserApp.Application.Users.Models;

namespace UserApp.Infrastructure.Persistance.Configurations
{
    public class ExternalUserService : IExternalUserService
    {
        private readonly HttpClient _httpClient;
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
    }
}
