using EntityConfiguration.ManyToMany.DirectNavigation.DataContexts;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<LibraryDbContext>();
options.UseNpgsql("Host=localhost;Port=5432;Database=EntityConfiguration.ManyToMany.DirectNavigation;Username=postgres;Password=postgres");

var dbContext = new LibraryDbContext(options.Options);

var books = await dbContext.Books
    .Include(book => book.Authors)
    .ToListAsync();

Console.ReadLine();