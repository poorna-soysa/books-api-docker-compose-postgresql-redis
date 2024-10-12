var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresDatabase")));

builder.Services.AddStackExchangeRedisCache(
    options => options.Configuration = builder.Configuration.GetConnectionString("RedisCache"));

builder.Services.AddScoped<IRedisCacheService,RedisCacheService>();
builder.Services.AddScoped<IBookService,BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.MapBookEndpoints();

app.Run();
