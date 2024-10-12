namespace Books.Api.Docker.Services.Caching;

public interface IRedisCacheService
{
    Task<T?> GetDataAsync<T>(string key, CancellationToken cancellationToken);
    Task SetDataAsync<T>(string key, T data, CancellationToken cancellationToken);
    Task RemoveDataAsync(string key, CancellationToken cancellationToken);
}
