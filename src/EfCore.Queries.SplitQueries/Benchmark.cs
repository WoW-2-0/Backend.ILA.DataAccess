using BenchmarkDotNet.Attributes;
using EfCore.Queries.SplitQueries.Data;
using EfCore.Queries.SplitQueries.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EfCore.Queries.SplitQueries;

public class Benchmark
{
    private LibraryDbContext _context;

    [GlobalSetup]
    public void Setup()
    {
        var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SplitQueryExample;Username=postgres;Password=postgres");

        _context = new LibraryDbContext(optionsBuilder.Options);
        _context.Database.EnsureCreated();
        _context.InitializeSeedData().AsTask().Wait();
    }

    // public Benchmark()
    // {
    //     var services = new ServiceCollection();
    //
    //     services.AddDbContext<LibraryDbContext>(
    //         options => options.UseNpgsql("Host=localhost;Port=5432;Database=SplitQueryExample;Username=postgres;Password=postgres")
    //     );
    //
    //     _serviceProvider = services.BuildServiceProvider();
    //
    //     var scopeProvider = _serviceProvider.CreateScope().ServiceProvider;
    //     var dbContext = scopeProvider.GetRequiredService<LibraryDbContext>();
    //
    //     dbContext.InitializeSeedData().AsTask().Wait();
    // }

    [Benchmark]
    public async Task LoadDataWithSplitQuery()
    {
        _ = await _context.Books.Include(book => book.Reviews).AsSplitQuery().Take(10).ToListAsync();
    }

    [Benchmark]
    public async Task LoadDataWithSingleQuery()
    {
        _ = await _context.Books.Include(book => book.Reviews).Take(10).ToListAsync();
    }
}