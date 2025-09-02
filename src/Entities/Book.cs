namespace Books.Api.Docker.Entities;

public sealed class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}
