





## Replacing a relationship 




#### Many-to-Many

For example this would only remove `AuthorBook` table, meaning it will remove book's authors.

```C#
author.Books = new List<Book>
{
    new()
    {
        Title = "Pro C# 12 and .NET 8",
        Genre = "Programming",
        Pages = 1200
    }
}

await dbContext.SaveChangesAsync();
};
```