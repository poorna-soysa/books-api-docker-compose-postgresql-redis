namespace Books.Api.Docker.Entities;

public sealed class Book
{
    public int Id { get; set; }

    public string Title { get; set; }
    public string ISBN { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
}
