namespace Books.Api.Docker.Endpoints;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this IEndpointRouteBuilder app)
    {
        var bookGroup = app.MapGroup("books");

        // Get All
        bookGroup.MapGet("", async (
            IBookService bookService,
            CancellationToken cancellationToken) =>
        {
            var books = await bookService.GetBooksAsync(cancellationToken);

            return Results.Ok(books.Select(b => new BookResponse
                (
                b.Id,
                b.Title,
                b.ISBN,
                b.Description,
                b.Author
                )));
        });


        // Get by Id
        bookGroup.MapGet("{id}", async (
            int id,
            IBookService bookService,
            IRedisCacheService cacheService,
            CancellationToken cancellationToken) =>
        {
            var cacheKey = $"book={id}";

            var response = cacheService.GetData<BookResponse>(cacheKey);

            if (response is not null)
            {
                return Results.Ok(response);
            }

            var book = await bookService.GetBookByIdAsync(id, cancellationToken);

            if (book is null)
            {
                return Results.NotFound();
            }

            response = new(
               book.Id,
               book.Title,
               book.ISBN,
               book.Description,
               book.Author);

            cacheService.SetData<BookResponse>(cacheKey, response);

            return Results.Ok(response);
        });

        //Create
        bookGroup.MapPost("", async (
            CreateBookRequest request,
            IBookService bookService,
            CancellationToken cancellationToken) =>
        {
            var book = new Book
            {
                Title = request.Title,
                ISBN = request.ISBN,
                Description = request.Description,
                Author = request.Author
            };

            book.Id = await bookService.CreateBookAsync(book, cancellationToken);

            return Results.Ok(Results.Created($"{book.Id}", book));
        });

        // Update
        bookGroup.MapPut("{id}", async (
            int id,
            UpdateBookRequest request,
            IBookService bookService,
            CancellationToken cancellationToken) =>
        {
            var book = new Book
            {
                Id = id,
                Title = request.Title,
                ISBN = request.ISBN,
                Description = request.Description,
                Author = request.Author
            };

            await bookService.UpdateBookAsync(book, cancellationToken);

            return Results.NoContent();
        });


        // Delete
        bookGroup.MapDelete("{id}", async (
            int id,
            IBookService bookService,
            CancellationToken cancellationToken) =>
        {
            await bookService.DeleteBookByIdAsync(id, cancellationToken);

            return Results.NoContent();
        });
    }
}
