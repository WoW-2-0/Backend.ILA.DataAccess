using EfCore.Queries.GlobalQueryFilter.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Queries.GlobalQueryFilter.DataContexts;

public class LibraryDbContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();

    public DbSet<Book> Books => Set<Book>();

    public DbSet<AuthorBook> AuthorBooks => Set<AuthorBook>();
    
    public LibraryDbContext() : base(new DbContextOptionsBuilder<LibraryDbContext>()
        .UseNpgsql("Host=localhost;Port=5432;Database=GlobalQueryFilter;Username=postgres;Password=postgres")
        .Options)
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
    }
}