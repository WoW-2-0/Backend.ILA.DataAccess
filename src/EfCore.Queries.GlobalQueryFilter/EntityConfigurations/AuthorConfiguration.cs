using EfCore.Queries.GlobalQueryFilter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Queries.GlobalQueryFilter.EntityConfigurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasData(new Author
            {
                Id = Guid.Parse("4941DEC3-36F6-412D-BABC-ABD92B79B9BB"),
                Name = "Andrew Troelsen"
            },
            new Author
            {
                Id = Guid.Parse("E0817981-A236-4836-BBDD-326DDB6565D3"),
                Name = "Mark. J. Price",
                IsDeleted = true,
                DeletedTime = DateTimeOffset.Now
            });

        builder.HasQueryFilter(author => !author.IsDeleted);
    }
}