namespace Books.Api.Docker.Services;

public interface IBookService
{
    public Task<Book?> GetBookByIdAsync(int id, CancellationToken cancellationToken);
    public Task<IEnumerable<Book>> GetBooksAsync(CancellationToken cancellationToken);
    public Task<int> CreateBookAsync(Book book, CancellationToken cancellationToken);
    public Task UpdateBookAsync(Book book, CancellationToken cancellationToken);
    public Task DeleteBookByIdAsync(int id, CancellationToken cancellationToken);
}
