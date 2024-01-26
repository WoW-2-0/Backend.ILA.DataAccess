namespace EntityConfiguration.ManyToMany.DirectNavigation.Models;

public class BookAuthor
{
    public BookAuthor()
    {
        
    }

    public BookAuthor(Guid bookId, Guid authorId) => (BookId, AuthorId) = (bookId, authorId);
    
    public Guid BookId { get; set; }
    
    public Guid AuthorId { get; set; }
}