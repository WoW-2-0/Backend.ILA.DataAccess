namespace EfCore.Queries.NonTrackedEntities.Models;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public IList<BookReview> Reviews { get; set; } = new List<BookReview>();
}