using System.Text.Json;
using EfCore.Queries.NonTrackedEntities.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddDbContext<LibraryDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=NonTrackedEntitiesExample;Username=postgres;Password=postgres"));

var serviceProvider = services.BuildServiceProvider();

await using var scope = serviceProvider.CreateAsyncScope();
var scopeProvider = scope.ServiceProvider;

var dbContextA = scopeProvider.GetRequiredService<LibraryDbContext>();

// Example with .AsNoTracking()
var initialQuery = dbContextA.BookReviews.AsNoTracking().Include(review => review.Book);
var reviewA = await initialQuery.Where(review => review.BookId == Guid.Parse("AEA165F8-69E5-4605-B45B-1E66227445BA")).ToListAsync();

Console.WriteLine("With AsNoTracking:");
Console.WriteLine(reviewA.First().Book.Equals(reviewA.Last().Book));

var dbContextB = scopeProvider.GetRequiredService<LibraryDbContext>();

// Example with .AsNoTrackingWithIdentityResolution()
var initialQuery2 = dbContextB.BookReviews.AsNoTrackingWithIdentityResolution().Include(review => review.Book);
var reviewB = await initialQuery2.Where(review => review.BookId == Guid.Parse("AEA165F8-69E5-4605-B45B-1E66227445BA")).ToListAsync();

Console.WriteLine("With AsNoTrackingWithIdentityResolution:");
Console.WriteLine(reviewB.First().Book.Equals(reviewB.Last().Book));