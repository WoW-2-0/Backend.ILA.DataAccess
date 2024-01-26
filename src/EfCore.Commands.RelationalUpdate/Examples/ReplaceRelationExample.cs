using EfCore.Commands.RelationalUpdate.DataContexts;
using EfCore.Commands.RelationalUpdate.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Commands.RelationalUpdate.Examples;

public class ReplaceRelationExample
{
    private readonly LibraryDbContext _dbContext;

    public ReplaceRelationExample(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask ExecuteAsync()
    {
        var andrew =
            await _dbContext.Authors.Include(author => author.Biography)
                .Include(author => author.Books)
                .OrderBy(author => author.Id)
                .FirstOrDefaultAsync() ?? throw new InvalidOperationException();

        var mark = new Author(Guid.Parse("E0817981-A236-4836-BBDD-326DDB6565D3"));

        // one-to-one relation

        // connected state
        andrew.Biography = new AuthorBiography
        {
            Content = "This is Andrew's biography v1"
        };
        await _dbContext.SaveChangesAsync();

        // disconnected state
        var oldBiography = await _dbContext.AuthorBiographies
            .Where(biography => biography.AuthorId == Guid.Parse("E0817981-A236-4836-BBDD-326DDB6565D3"))
            .FirstOrDefaultAsync() ?? throw new InvalidOperationException();
        _dbContext.AuthorBiographies.Remove(oldBiography);
        await _dbContext.AddAsync(new AuthorBiography
        {
            AuthorId = Guid.Parse("E0817981-A236-4836-BBDD-326DDB6565D3"),
            Content = "This is Mark's biography v1"
        });
        await _dbContext.SaveChangesAsync();

        // many-to-many relation

        // connected state
        await _dbContext.AuthorBooks.Where(authorBook => authorBook.AuthorId == mark.Id).ExecuteDeleteAsync();
        andrew.Books = new List<Book>
        {
            new()
            {
                Title = "Pro C# 12 and .NET 8",
                Genre = "Programming",
                Pages = 1200
            }
        };
        await _dbContext.SaveChangesAsync();

        // disconnected state
        await _dbContext.AuthorBooks.Where(authorBook => authorBook.AuthorId == mark.Id).ExecuteDeleteAsync();
        _dbContext.Authors.Attach(mark);
        _dbContext.Books.Add(new Book
        {
            Authors = new List<Author>(new[] { mark }),
            Title = "C# 11 and .NET 7",
            Genre = "Programming",
            Pages = 1200
        });

        await _dbContext.SaveChangesAsync();
        _dbContext.Entry(mark).State = EntityState.Detached;

        // one-to-many relation

        // connected state
        andrew.Books.First()
            .Reviews.Add(new BookReview
            {
                Review = "Pro C# 12 and .NET 8 is a great book"
            });
        await _dbContext.SaveChangesAsync();

        andrew.Books.First().Reviews = new List<BookReview>(new[]
        {
            new BookReview
            {
                Review = "Amazing with great explanation of the NET Core 8 features"
            }
        });
        await _dbContext.SaveChangesAsync();

        // disconnected state
        _dbContext.Authors.Attach(mark);

        mark.Books.First()
            .Reviews.Add(new BookReview
            {
                Review = "C# 11 and .NET 7 is a great book"
            });
        await _dbContext.SaveChangesAsync();

        mark.Books.First().Reviews = new List<BookReview>(new[]
        {
            new BookReview
            {
                Review = "Another great book by Mark"
            }
        });
        await _dbContext.SaveChangesAsync();

        _dbContext.Entry(mark).State = EntityState.Detached;

        var andewsState = _dbContext.Entry(andrew).State;
        var marksState = _dbContext.Entry(mark).State;
    }
}