using Books.Api.Docker.Entities;

namespace Books.Api.Docker.Database;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{

    public DbSet<Book> Books { get; set; }
}
