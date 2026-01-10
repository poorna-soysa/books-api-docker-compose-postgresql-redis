namespace Books.Api.Docker.Services;

public sealed class BookService(ApplicationDbContext context) : IBookService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> CreateBookAsync(Book book, CancellationToken cancellationToken)
    {
        _context.Books.Add(book);

        await _context.SaveChangesAsync(cancellationToken);
        return book.Id;
    }

    public async Task DeleteBookByIdAsync(int id, CancellationToken cancellationToken)
    {
        var book = await _context.Books
             .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

        if (book is null)
        {
            throw new ArgumentException($"Book is not foud Id {id}");
        }

        _context.Books.Remove(book);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Book?> GetBookByIdAsync(int id, CancellationToken cancellationToken)
          => await _context.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<IEnumerable<Book>> GetBooksAsync(CancellationToken cancellationToken)
        => await _context.Books
        .AsNoTracking()
        .OrderBy(o => o.Id)
        .ToListAsync(cancellationToken);

    public async Task UpdateBookAsync(Book book, CancellationToken cancellationToken)
    {
        var bookObj = await _context.Books
             .FirstOrDefaultAsync(b => b.Id == book.Id, cancellationToken);

        if (bookObj is null)
        {
            throw new ArgumentException($"Book is not found with Id {book.Id}");
        }

        bookObj.Title = book.Title;
        bookObj.ISBN = book.ISBN;
        bookObj.Description = book.Description;
        bookObj.Author = book.Author;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
