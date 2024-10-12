namespace Books.Api.Docker.Extensions;

public static class PostgreSqlExtensions
{
    public static IServiceCollection AddPostgreSqlConfig(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("PostgresDatabase")));

        return services;
    }
}
