using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EfCore.Queries.GlobalQueryFilter.Models;

public class Author : SoftDeletedEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public IList<Book> Books { get; set; } = new List<Book>();
}