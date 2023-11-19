namespace EfCore.Queries.NonTrackedEntities.Models;

public class BookReview
{
    public Guid Id { get; set; }
    
    public Guid BookId { get; set; }
    
    public string Review { get; set; } = string.Empty;

    public Book Book { get; set; }
}