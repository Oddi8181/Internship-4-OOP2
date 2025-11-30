namespace UserApp.Infrastructure.Persistance.Configurations
{
    using Microsoft.Extensions.Caching.Memory;
    using UserApp.Domain.Persistance.Users;

    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        public MemoryCacheService(IMemoryCache cache) => _cache = cache;

        public Task<T?> GetAsync<T>(string key)
        {
            if (_cache.TryGetValue<T>(key, out var value))
                return Task.FromResult<T?>(value);
            return Task.FromResult<T?>(default);
        }

        public Task SetAsync<T>(string key, T value, DateTimeOffset absoluteExpiration)
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = absoluteExpiration
            };
            _cache.Set(key, value, options);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(string key)
        {
            _cache.Remove(key);
            return Task.CompletedTask;
        }

        
        public static DateTimeOffset EndOfToday()
        {
            var now = DateTime.Now;
            var end = new DateTime(now.Year, now.Month, now.Day).AddDays(1).AddTicks(-1);
            return new DateTimeOffset(end);
        }

       
    }

}
