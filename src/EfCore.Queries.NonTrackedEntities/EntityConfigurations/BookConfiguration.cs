using EfCore.Queries.NonTrackedEntities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Queries.NonTrackedEntities.EntityConfigurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(new Book
            {
                Id = Guid.Parse("AEA165F8-69E5-4605-B45B-1E66227445BA"),
                Title = "Asp.NET Core in Action"
            },
            new Book
            {
                Id = Guid.Parse("D0BA9D76-F454-41B6-AAD8-23DCEA4EF167"),
                Title = "C# 12 and .Net 8"
            });
    }
}