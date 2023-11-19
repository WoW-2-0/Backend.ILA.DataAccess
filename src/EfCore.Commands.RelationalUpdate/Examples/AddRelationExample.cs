using EfCore.Commands.RelationalUpdate.DataContexts;
using EfCore.Commands.RelationalUpdate.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Commands.RelationalUpdate.Examples;

// relation configuration
// add, replace, remove - 

// author and author biography - 

public class AddRelationExample
{
    private readonly LibraryDbContext _dbContext;

    public AddRelationExample(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask ExecuteAsync()
    {
        var andrew =
            await _dbContext.Authors.Include(author => author.Books)
                .OrderBy(author => author.Id)
                .FirstOrDefaultAsync() ?? throw new InvalidOperationException();

        var mark = new Author(Guid.Parse("E0817981-A236-4836-BBDD-326DDB6565D3"));

        // one-to-one relation

        // connected state update
        var andrewBiography = new AuthorBiography
        {
            Content = "This is the biography of the author"
        };
        andrew.Biography = andrewBiography;
        await _dbContext.SaveChangesAsync();

        // disconnected state update
        var authorBiography = new AuthorBiography
        {
            AuthorId = Guid.Parse("E0817981-A236-4836-BBDD-326DDB6565D3"),
            Content = "This is the biography of the author"
        };

        _dbContext.Add(authorBiography);
        await _dbContext.SaveChangesAsync();

        // many-to-many relation

        // connected state
        andrew.Books.Add(new Book
        {
            Title = "Asp.NET Core 8 in Action",
            Genre = "Programming",
            Pages = 1200
        });
        await _dbContext.SaveChangesAsync();

        // disconnected state
        _dbContext.Authors.Attach(mark);
        var test = _dbContext.Entry(mark).State;
        _dbContext.Books.Add(new Book
        {
            Authors = new List<Author>(new[] { mark }),
            Title = "C# 12 and .NET 8",
            Genre = "Programming",
            Pages = 1200
        });
        await _dbContext.SaveChangesAsync();
        var bookId = (await _dbContext.Books.OrderByDescending(book => book.Id).LastOrDefaultAsync() ??
                      throw new InvalidOperationException()).Id;

        _dbContext.Entry(mark).State = EntityState.Detached;

        // one-to-many relation

        // connected state
        andrew.Books.First()
            .Reviews.Add(new BookReview
            {
                Review = "This is a review of the book"
            });
        await _dbContext.SaveChangesAsync();

        // disconnected state
        _dbContext.BookReviews.Add(new BookReview
        {
            BookId = bookId,
            Review = "C# 12 and .NET 8 is a great book"
        });
        await _dbContext.SaveChangesAsync();

        var andewsState = _dbContext.Entry(andrew).State;
        var marksState = _dbContext.Entry(mark).State;
    }
}