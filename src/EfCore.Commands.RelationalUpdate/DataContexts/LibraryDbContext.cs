using EfCore.Commands.RelationalUpdate.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Commands.RelationalUpdate.DataContexts;

public class LibraryDbContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();

    public DbSet<Book> Books => Set<Book>();
    
    public DbSet<AuthorBook> AuthorBooks => Set<AuthorBook>("AuthorBooks");

    public DbSet<AuthorBiography> AuthorBiographies => Set<AuthorBiography>();

    public DbSet<BookReview> BookReviews => Set<BookReview>();
    
    public LibraryDbContext() : base(new DbContextOptionsBuilder<LibraryDbContext>()
        .UseNpgsql("Host=localhost;Port=5432;Database=RelationalUpdate;Username=postgres;Password=postgres")
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