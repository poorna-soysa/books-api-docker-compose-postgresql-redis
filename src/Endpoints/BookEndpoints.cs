using Books.Api.Docker.Database;
using Books.Api.Docker.Dtos;
using Books.Api.Docker.Entitties;
using Microsoft.EntityFrameworkCore;

namespace Books.Api.Docker.Endpoints;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this IEndpointRouteBuilder app)
    {
        var bookGroup = app.MapGroup("books");

        // Get All
        bookGroup.MapGet("", async (
            ApplicationDbContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var books = await dbContext.Books
                .AsNoTracking()
                 .Select(b => new BookResponse(
                     b.Id,
                     b.Title,
                     b.ISBN,
                     b.Description,
                     b.Author))
                .ToListAsync();

            return Results.Ok(books);
        });


        // Get by Id
        bookGroup.MapGet("{id}", async (
            int id,
            ApplicationDbContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var book = await dbContext.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

            if (book is null)
            {
                return Results.NotFound();
            }

            BookResponse response = new(
                book.Id,
                book.Title,
                book.ISBN,
                book.Description,
                book.Author);

            return Results.Ok(response);
        });

        //Create
        bookGroup.MapPost("", async (
            CreateBookRequest request,
            ApplicationDbContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var book = new Book
            {
                Title = request.Title,
                ISBN = request.ISBN,
                Description = request.Description,
                Author = request.Author
            };

            dbContext.Add(book);

            await dbContext.SaveChangesAsync(cancellationToken);

            return Results.Ok(Results.Created($"{book.Id}", book));
        });

        // Update
        bookGroup.MapPut("{id}", async (
            int id,
            UpdateBookRequest request,
            ApplicationDbContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var book = await dbContext.Books
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

            if (book is null)
            {
                return Results.NotFound();
            }

            book.Title = request.Title;
            book.ISBN = request.ISBN;
            book.Description = request.Description;
            book.Author = request.Author;

            await dbContext.SaveChangesAsync(cancellationToken);

            return Results.NoContent();
        });


        // Delete
        bookGroup.MapDelete("{id}", async (
            int id,
            ApplicationDbContext dbContext,
            CancellationToken cancellationToken) =>
        {
            var book = await dbContext.Books
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

            if (book is null)
            {
                return Results.NotFound();
            }

            dbContext.Remove(book);

            await dbContext.SaveChangesAsync(cancellationToken);

            return Results.NoContent();
        });
    }
}
