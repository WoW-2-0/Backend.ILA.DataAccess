using EfCore.Queries.GlobalQueryFilter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Queries.GlobalQueryFilter.EntityConfigurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasMany(book => book.Authors)
            .WithMany(author => author.Books)
            .UsingEntity<AuthorBook>(
                joinTable => joinTable.HasOne(authorBook => authorBook.Author)
                    .WithMany()
                    .IsRequired(false)
                    .HasForeignKey(authorBook => authorBook.AuthorId),
                joinTable => joinTable.HasOne(authorBook => authorBook.Book)
                    .WithMany()
                    .IsRequired(false)
                    .HasForeignKey(authorBook => authorBook.BookId),
                joinTable => joinTable.HasKey(authorBook => new
                {
                    authorBook.AuthorId,
                    authorBook.BookId
                }));

        builder.HasIndex(book => new
            {
                book.Title,
                book.IsDeleted
            })
            .IsUnique();

        builder.HasQueryFilter(book => !book.IsDeleted);

        builder.HasData(new Book
            {
                Id = Guid.Parse("4abd35a4-1d02-4e3f-9cca-50446c824540"),
                Title = "Pro C# 7: With .NET and .NET Core",
                Genre = "Programming",
                Pages = 1376,
            },
            new Book
            {
                Id = Guid.Parse("845f0813-88ee-4dfb-9e1f-8d8bb1c1e686"),
                Title = "Complete C# 7 Design Patterns",
                Genre = "Programming",
                Pages = 900,
            },
            new Book
            {
                Id = Guid.Parse("ea55317a-2836-46f6-ad53-d10da0647ed9"),
                Title = "Pro C# 12 with .NET 8",
                Genre = "Programming",
                Pages = 900,
                IsDeleted = true,
                DeletedTime = DateTimeOffset.Now,
            });
    }
}