namespace EfCore.Queries.SplitQueries.Models;

public class Book
{
    public Book(string title)
    {
        Title = title;
    }

    public Book()
    {
        
    }

    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public IList<BookReview> Reviews { get; set; } = new List<BookReview>();
}