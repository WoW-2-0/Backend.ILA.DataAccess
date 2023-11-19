using EfCore.Queries.NonTrackedEntities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Queries.NonTrackedEntities.EntityConfigurations;

public class BookReviewConfiguration : IEntityTypeConfiguration<BookReview>
{
    public void Configure(EntityTypeBuilder<BookReview> builder)
    {
        builder.HasOne<Book>(review => review.Book).WithMany(book => book.Reviews).HasForeignKey(review => review.BookId);

        builder.HasData(new BookReview
            {
                Id = Guid.Parse("1C832FC1-1146-4AA8-819C-E6E0788A4E50"),
                BookId = Guid.Parse("AEA165F8-69E5-4605-B45B-1E66227445BA"),
                Review = "Great book"
            },
            new BookReview()
            {
                Id = Guid.Parse("C7E81257-582E-4B4F-96D3-96DC8506B9DA"),
                BookId = Guid.Parse("AEA165F8-69E5-4605-B45B-1E66227445BA"),
                Review = "Awesome book"
            });
    }
}