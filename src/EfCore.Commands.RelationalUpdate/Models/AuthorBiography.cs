namespace EfCore.Commands.RelationalUpdate.Models;

public class AuthorBiography
{
    public Guid Id { get; set; }
    
    public Guid AuthorId { get; set; }

    public string Content { get; set; } = default!;
    
    public Author Author { get; set; }
}