using EfCore.Commands.RelationalUpdate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Commands.RelationalUpdate.EntityConfigurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .HasMany(book => book.Authors)
            .WithMany(author => author.Books)
            .UsingEntity<AuthorBook>(
                "AuthorBooks",
                joinTable => joinTable.HasOne(authorBook => authorBook.Author)
                    .WithMany()
                    .HasForeignKey(authorBook => authorBook.AuthorId),
                joinTable => joinTable.HasOne(authorBook => authorBook.Book)
                    .WithMany()
                    .HasForeignKey(authorBook => authorBook.BookId),
                joinTable => joinTable.HasKey(authorBook => new
                {
                    authorBook.AuthorId,
                    authorBook.BookId
                }));
    }
}