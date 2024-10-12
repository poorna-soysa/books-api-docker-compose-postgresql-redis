using Books.Api.Docker.Entitties;
using Microsoft.EntityFrameworkCore;

namespace Books.Api.Docker.Database;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{

    public DbSet<Book> Books { get; set; }
}
