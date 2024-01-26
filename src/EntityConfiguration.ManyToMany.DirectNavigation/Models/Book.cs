namespace EntityConfiguration.ManyToMany.DirectNavigation.Models;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public List<Author>? Authors { get; set; }
}