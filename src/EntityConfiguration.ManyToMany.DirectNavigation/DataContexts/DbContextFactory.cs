using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EntityConfiguration.ManyToMany.DirectNavigation.DataContexts;

public class DbContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
{
    public LibraryDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EntityConfiguration.ManyToMany.DirectNavigation;Username=postgres;Password=postgres");

        return new LibraryDbContext(optionsBuilder.Options);
    }
}