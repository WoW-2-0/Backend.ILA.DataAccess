using EfCore.Queries.SplitQueries.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Queries.SplitQueries.DataContexts;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();

    public DbSet<BookReview> BookReviews => Set<BookReview>();

    public LibraryDbContext() : base(new DbContextOptionsBuilder<LibraryDbContext>()
        .UseNpgsql("Host=localhost;Port=5432;Database=SplitQueryExample;Username=postgres;Password=postgres")
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