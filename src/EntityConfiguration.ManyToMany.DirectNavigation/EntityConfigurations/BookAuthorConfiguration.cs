using EntityConfiguration.ManyToMany.DirectNavigation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration.ManyToMany.DirectNavigation.EntityConfigurations;

public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.HasData(
            new List<BookAuthor>
            {
                new(Guid.Parse("E9582B0D-A6C7-4FDB-B17B-7E9D64E5B784"), Guid.Parse("4941DEC3-36F6-412D-BABC-ABD92B79B9BB")),
                new(Guid.Parse("A1B2C3D4-E5F6-47A8-B9C0-D1E2F3A4B5C6"), Guid.Parse("A67CDFFC-F7A4-4D23-A882-49A6DF9C817F")),
                new(Guid.Parse("B2C3D4E5-F6A7-48B9-C0D1-E2F3A4B5C6D7"), Guid.Parse("4399C1F6-896E-4D54-A88F-1D7206D8997F")),
                new(Guid.Parse("C3D4E5F6-A7B8-49C0-D1E2-F3A4B5C6D7E8"), Guid.Parse("B657D94D-0710-415C-8C31-A5E8680B31ED")),
                new(Guid.Parse("D4E5F6A7-B8C9-4AD0-E1F2-A3B4C5D6E7F8"), Guid.Parse("6CEF5459-8106-4086-A613-5B19AFDE6163")),
                new(Guid.Parse("E6F7A8B9-C0D1-4AE2-F3B4-C5D6E7F8A9B0"), Guid.Parse("4399C1F6-896E-4D54-A88F-1D7206D8997F")),
                new(Guid.Parse("E6F7A8B9-C0D1-4AE2-F3B4-C5D6E7F8A9B0"), Guid.Parse("B657D94D-0710-415C-8C31-A5E8680B31ED"))
            }
        );
    }
}