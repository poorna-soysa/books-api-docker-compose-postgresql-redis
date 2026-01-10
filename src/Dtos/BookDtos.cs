using System.ComponentModel.DataAnnotations;

namespace Books.Api.Docker.Dtos;

public sealed record CreateBookRequest(
    [property: Required]
    [property: StringLength(200, MinimumLength = 1)]
    string Title,

    [property: Required]
    string ISBN,

    [property: StringLength(2000)]
    string Description,

    [property: Required]
    [property: StringLength(150)]
    string Author
);

public sealed record BookResponse(
    int Id,
    string Title,
    string ISBN,
    string Description,
    string Author);

public sealed record UpdateBookRequest(
    [property: Required]
    [property: StringLength(200, MinimumLength = 1)]
    string Title,

    [property: Required]
    string ISBN,

    [property: StringLength(2000)]
    string Description,

    [property: Required]
    [property: StringLength(150)]
    string Author
);