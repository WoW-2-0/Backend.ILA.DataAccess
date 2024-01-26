using EfCore.Queries.SplitQueries.DataContexts;
using EfCore.Queries.SplitQueries.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Queries.SplitQueries.Data;

public static class SeedData
{
    public static async ValueTask InitializeSeedData(this LibraryDbContext libraryDbContext)
    {
        if (!await libraryDbContext.Books.AnyAsync())
            await libraryDbContext.AddBooksAsync();

        if (!await libraryDbContext.BookReviews.AnyAsync())
            await libraryDbContext.AddBookReviews();
    }

    private static async ValueTask AddBooksAsync(this LibraryDbContext libraryDbContext)
    {
        for (var index = 0; index < 100; index++)
            libraryDbContext.Books.Add(new Book("Test book"));

        // await libraryDbContext.AddRangeAsync(
        //     new Book("Clean Code: A Handbook of Agile Software Craftsmanship"),
        //     new Book("Design Patterns: Elements of Reusable Object-Oriented Software"),
        //     new Book("Refactoring: Improving the Design of Existing Code"),
        //     new Book("Introduction to the Theory of Computation"),
        //     new Book("You Don't Know JS"),
        //     new Book("The Pragmatic Programmer: Your Journey to Mastery" + "Head First Design Patterns: A Brain-Friendly Guide"),
        //     new Book("The Art of Computer Programming"),
        //     new Book("Code Complete: A Practical Handbook of Software Construction"),
        //     new Book("The Mythical Man-Month: Essays on Software Engineering")
        // );
        
        await libraryDbContext.SaveChangesAsync();
    }

    private static async ValueTask AddBookReviews(this LibraryDbContext libraryDbContext)
    {
        var books = await libraryDbContext.Books.ToListAsync();

        books.ForEach(
            book =>
            {
                for (var index = 0; index < 100; index++)
                    libraryDbContext.BookReviews.Add(
                        new BookReview
                        {
                            BookId = book.Id,
                            Review = "Test review"
                        }
                    );
            }
        );

        await libraryDbContext.SaveChangesAsync();
    }
}