using EfCore.Commands.RelationalUpdate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Commands.RelationalUpdate.EntityConfigurations;

public class AuthorBiographyConfiguration : IEntityTypeConfiguration<AuthorBiography>
{
    public void Configure(EntityTypeBuilder<AuthorBiography> builder)
    {
        builder
            .HasOne<Author>(biography => biography.Author)
            .WithOne(author => author.Biography)
            .HasForeignKey<AuthorBiography>(biography => biography.AuthorId);
    }
}