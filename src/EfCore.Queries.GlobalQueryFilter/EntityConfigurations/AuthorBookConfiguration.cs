using EfCore.Queries.GlobalQueryFilter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Queries.GlobalQueryFilter.EntityConfigurations;

public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
{
    public void Configure(EntityTypeBuilder<AuthorBook> builder)
    {
        builder.HasData(new AuthorBook
            {
                AuthorId = Guid.Parse("4941DEC3-36F6-412D-BABC-ABD92B79B9BB"),
                BookId = Guid.Parse("4abd35a4-1d02-4e3f-9cca-50446c824540")
            },
            new AuthorBook
            {
                AuthorId = Guid.Parse("4941DEC3-36F6-412D-BABC-ABD92B79B9BB"),
                BookId = Guid.Parse("845f0813-88ee-4dfb-9e1f-8d8bb1c1e686")
            },
            new AuthorBook
            {
                AuthorId = Guid.Parse("E0817981-A236-4836-BBDD-326DDB6565D3"),
                BookId = Guid.Parse("845f0813-88ee-4dfb-9e1f-8d8bb1c1e686")
            },
            new AuthorBook
            {
                AuthorId = Guid.Parse("4941DEC3-36F6-412D-BABC-ABD92B79B9BB"),
                BookId = Guid.Parse("ea55317a-2836-46f6-ad53-d10da0647ed9")
            });
    }
}