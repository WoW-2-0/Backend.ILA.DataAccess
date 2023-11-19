namespace EfCore.Queries.GlobalQueryFilter.Models;

public class Book : SoftDeletedEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public int Pages { get; set; }
    
    public IList<Author> Authors { get; set; } = new List<Author>();
}