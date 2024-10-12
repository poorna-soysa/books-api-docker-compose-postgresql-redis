namespace Books.Api.Docker.Services.Caching;

public class RedisCacheService(IDistributedCache cache) : IRedisCacheService
{
    public async Task<T?> GetDataAsync<T>(string key, CancellationToken cancellationToken)
    {
        string? data = await cache.GetStringAsync(key, cancellationToken);

        if (string.IsNullOrEmpty(data))
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(data);
    }

    public async Task RemoveDataAsync(string key, CancellationToken cancellationToken)
            => await cache.RemoveAsync(key, cancellationToken);

    public async Task SetDataAsync<T>(
        string key,
        T data,
        CancellationToken cancellationToken)
    {
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        await cache.SetStringAsync(
            key,
            JsonSerializer.Serialize(data),
            options);
    }
}
