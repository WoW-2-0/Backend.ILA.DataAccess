using EfCore.Commands.RelationalUpdate.DataContexts;
using EfCore.Commands.RelationalUpdate.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Commands.RelationalUpdate.Examples;

public class RemoveRelationExample
{
    private readonly LibraryDbContext _dbContext;

    public RemoveRelationExample(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask ExecuteAsync()
    {
        var andrew =
            await _dbContext.Authors.Include(author => author.Books)
                .ThenInclude(book => book.Reviews)
                .Include(author => author.Biography)
                .OrderBy(author => author.Id)
                .FirstOrDefaultAsync() ?? throw new InvalidOperationException();

        var mark = new Author(Guid.Parse("E0817981-A236-4836-BBDD-326DDB6565D3"));

        // one-to-one relation

        // connected state
        andrew.Biography = null;
        await _dbContext.SaveChangesAsync();

        // batch - ko'plikda
        // bulk - ko'plikda
        
        // disconnected state
        await _dbContext.AuthorBiographies.Where(biography => biography.AuthorId == mark.Id).ExecuteDeleteAsync();

        // one-to-many relation

        // connected state
        andrew.Books.First().Reviews = null;
        await _dbContext.SaveChangesAsync();

        // disconnected state
        await _dbContext.BookReviews
            .Include(review => review.Book)
            .ThenInclude(book => book.Authors)
            .Where(review => review.Book.Authors.Any(author => author.Id.Equals(mark.Id)))
            .ExecuteDeleteAsync();

        andrew.Books.Clear();
        await _dbContext.SaveChangesAsync();

        // disconnected state
        var booksToDelete = _dbContext.AuthorBooks.Include(authorBook => authorBook.Book)
            .Where(authorBook => authorBook.AuthorId == mark.Id)
            .Select(authorBook => authorBook.BookId)
            .ToList();

        await _dbContext.Books.Where(book => booksToDelete.Contains(book.Id)).ExecuteDeleteAsync();

        var andewsState = _dbContext.Entry(andrew).State;
        var marksState = _dbContext.Entry(mark).State;
    }
}