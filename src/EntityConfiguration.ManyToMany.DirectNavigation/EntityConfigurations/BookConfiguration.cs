using EntityConfiguration.ManyToMany.DirectNavigation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration.ManyToMany.DirectNavigation.EntityConfigurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(
            new Book
            {
                Id = Guid.Parse("E9582B0D-A6C7-4FDB-B17B-7E9D64E5B784"),
                Title = "Pro C# 7: With .NET and .NET Core",
                Genre = "Programming"
            },
            new Book
            {
                Id = Guid.Parse("A1B2C3D4-E5F6-47A8-B9C0-D1E2F3A4B5C6"),
                Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
                Genre = "Programming"
            },
            new Book
            {
                Id = Guid.Parse("B2C3D4E5-F6A7-48B9-C0D1-E2F3A4B5C6D7"),
                Title = "Refactoring: Improving the Design of Existing Code",
                Genre = "Programming"
            },
            new Book
            {
                Id = Guid.Parse("C3D4E5F6-A7B8-49C0-D1E2-F3A4B5C6D7E8"),
                Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software",
                Genre = "Programming"
            },
            new Book
            {
                Id = Guid.Parse("D4E5F6A7-B8C9-4AD0-E1F2-A3B4C5D6E7F8"),
                Title = "Code Complete: A Practical Handbook of Software Construction",
                Genre = "Programming"
            },
            new Book
            {
                Id = Guid.Parse("E6F7A8B9-C0D1-4AE2-F3B4-C5D6E7F8A9B0"),
                Title = "Patterns of Enterprise Application Architecture",
                Genre = "Programming"
            }
        );
        
        builder
            .HasMany(book => book.Authors)
            .WithMany(author => author.Books)
            .UsingEntity<BookAuthor>(bookAuthor => bookAuthor.ToTable($"{nameof(BookAuthor)}"));
    }
}