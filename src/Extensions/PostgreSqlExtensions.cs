namespace Books.Api.Docker.Extensions;

public static class PostgreSqlExtensions
{
    private const string ConnectionString = "PostgresDatabase";
    public static IServiceCollection AddPostgreSqlConfig(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString(ConnectionString)));

        return services;
    }

    public static IHealthChecksBuilder AddPostgreSqlHealth(this IHealthChecksBuilder services,
        IConfiguration configuration)
    {
        services.AddNpgSql(configuration.GetConnectionString(ConnectionString)!);

        return services;
    }
}
