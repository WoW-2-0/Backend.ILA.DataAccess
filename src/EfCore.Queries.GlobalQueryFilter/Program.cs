using System.Text.Json;
using EfCore.Queries.GlobalQueryFilter.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseNpgsql("Host=localhost;Port=5432;Database=GlobalQueryFilter;Username=postgres;Password=postgres");
    options.LogTo(Console.WriteLine);
});

var serviceProvider = services.BuildServiceProvider();

await using var scope = serviceProvider.CreateAsyncScope();
var scopeProvider = scope.ServiceProvider;

var dbContext = scopeProvider.GetRequiredService<LibraryDbContext>();

var books = await dbContext.Books
    .Include(book => book.Authors)
    .IgnoreQueryFilters()
    .ToListAsync();
Console.WriteLine(JsonSerializer.Serialize(books));