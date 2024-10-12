namespace Books.Api.Docker.Services.Caching;

public class RedisCacheService(IDistributedCache cache) : IRedisCacheService
{
    public T? GetData<T>(string key)
    {
        string? data = cache.GetString(key);

        if (string.IsNullOrEmpty(data))
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(data);
    }

    public void SetData<T>(string key, T data)
    {
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        cache.SetString(
            key,
            JsonSerializer.Serialize(data),
            options);
    }
}
