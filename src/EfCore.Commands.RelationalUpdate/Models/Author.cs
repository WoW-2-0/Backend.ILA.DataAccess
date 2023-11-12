using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Commands.RelationalUpdate.Models;

public class Author
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public AuthorBiography Biography { get; set; }

    public IList<Book> Books { get; set; } = new List<Book>();

    public Author()
    {
    }

    public Author(Guid id) => Id = id;
}