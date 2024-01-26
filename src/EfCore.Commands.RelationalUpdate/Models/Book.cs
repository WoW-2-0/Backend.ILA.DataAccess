using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Commands.RelationalUpdate.Models;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public int Pages { get; set; }
    
    public IList<Author> Authors { get; set; } = new List<Author>();
    
    public IList<BookReview> Reviews { get; set; } = new List<BookReview>();
}