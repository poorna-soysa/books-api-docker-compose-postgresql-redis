namespace Books.Api.Docker.Extensions;

public static class RedisExtensions
{
    public static IServiceCollection AddRedisConfig(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(
             options => options.Configuration = configuration.GetConnectionString("RedisCache"));

        return services;
    }
}