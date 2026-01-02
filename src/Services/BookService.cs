namespace Books.Api.Docker.Services;

public sealed class BookService(ApplicationDbContext context) : IBookService
{
    public async Task<int> CreateBookAsync(Book book, CancellationToken cancellationToken)
    {
        context.Add(book);

        await context.SaveChangesAsync(cancellationToken);
        return book.Id;
    }

    public async Task DeleteBookByIdAsync(int id, CancellationToken cancellationToken)
    {
        var book = await context.Books
             .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

        if (book is null)
        {
            throw new ArgumentException($"Book is not foud Id {id}");
        }

        context.Remove(book);

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Book?> GetBookByIdAsync(int id, CancellationToken cancellationToken)
          => await context.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<IEnumerable<Book>> GetBooksAsync(CancellationToken cancellationToken)
        => await context.Books
        .AsNoTracking()
        .OrderBy(o => o.Id)
        .ToListAsync(cancellationToken);

    public async Task UpdateBookAsync(Book book, CancellationToken cancellationToken)
    {
        var bookObj = await context.Books
             .FirstOrDefaultAsync(b => b.Id == book.Id, cancellationToken);

        if (bookObj is null)
        {
            throw new ArgumentException($"Book is not found with Id {book.Id}");
        }

        bookObj.Title = book.Title;
        bookObj.ISBN = book.ISBN;
        bookObj.Description = book.Description;
        bookObj.Author = book.Author;

        await context.SaveChangesAsync(cancellationToken);
    }
}
