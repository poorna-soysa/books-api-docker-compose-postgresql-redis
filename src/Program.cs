var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddPostgreSqlConfig(builder.Configuration)
    .AddRedisConfig(builder.Configuration)
    .AddHealthChecks()
    .AddPostgreSqlHealth(builder.Configuration)
    .AddRedisHealth(builder.Configuration);

builder.Services.AddValidation();

builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
#if DEBUG
    await app.ApplyMigrationsAsync();
#endif
}

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHttpsRedirection();

app.MapBookEndpoints();

app.Run();
