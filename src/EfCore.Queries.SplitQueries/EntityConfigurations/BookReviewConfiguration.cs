using EfCore.Queries.SplitQueries.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Queries.SplitQueries.EntityConfigurations;

public class BookReviewConfiguration : IEntityTypeConfiguration<BookReview>
{
    public void Configure(EntityTypeBuilder<BookReview> builder)
    {
        builder.HasOne<Book>(review => review.Book).WithMany(book => book.Reviews).HasForeignKey(review => review.BookId);
    }
}