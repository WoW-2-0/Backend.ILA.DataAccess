using EfCore.Commands.RelationalUpdate.DataContexts;
using EfCore.Commands.RelationalUpdate.Examples;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddDbContext<LibraryDbContext>(options =>
    {
        options.UseNpgsql("Host=localhost;Port=5432;Database=RelationalUpdate;Username=postgres;Password=postgres");
        options.LogTo(Console.WriteLine);
    })
    .AddScoped<AddRelationExample>()
    .AddScoped<ReplaceRelationExample>()
    .AddScoped<RemoveRelationExample>();

var serviceProvider = services.BuildServiceProvider();

await serviceProvider.CreateScope().ServiceProvider.GetRequiredService<AddRelationExample>().ExecuteAsync();
await serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ReplaceRelationExample>().ExecuteAsync();
await serviceProvider.CreateScope().ServiceProvider.GetRequiredService<RemoveRelationExample>().ExecuteAsync();