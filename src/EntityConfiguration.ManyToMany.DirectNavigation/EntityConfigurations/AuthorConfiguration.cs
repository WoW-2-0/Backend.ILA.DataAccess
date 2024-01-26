using EntityConfiguration.ManyToMany.DirectNavigation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration.ManyToMany.DirectNavigation.EntityConfigurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasData(
            new Author
            {
                Id = Guid.Parse("4941DEC3-36F6-412D-BABC-ABD92B79B9BB"),
                Name = "Andrew Troelsen"
            },
            new Author
            {
                Id = Guid.Parse("A67CDFFC-F7A4-4D23-A882-49A6DF9C817F"),
                Name = "Robert C. Martin"
            },
            new Author
            {
                Id = Guid.Parse("4399C1F6-896E-4D54-A88F-1D7206D8997F"),
                Name = "Martin Fowler"
            },
            new Author
            {
                Id = Guid.Parse("B657D94D-0710-415C-8C31-A5E8680B31ED"),
                Name = "Eric Evans"
            },
            new Author
            {
                Id = Guid.Parse("6CEF5459-8106-4086-A613-5B19AFDE6163"),
                Name = "Steve McConnell"
            }
        );
    }
}