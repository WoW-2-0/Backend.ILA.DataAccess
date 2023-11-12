using EfCore.Commands.RelationalUpdate.DataContexts;
using EfCore.Commands.RelationalUpdate.Examples;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services
    .AddDbContext<LibraryDbContext>(options =>
    {
        options.UseNpgsql("Host=localhost;Port=5432;Database=RelationalUpdate;Username=postgres;Password=postgres");
        options.LogTo(Console.WriteLine);
    })
    .AddScoped<AddRelationExample>()
    .AddScoped<ReplaceRelationExample>()
    .AddScoped<RemoveRelationExample>();

var serviceProvider = services.BuildServiceProvider();

await using var scope = serviceProvider.CreateAsyncScope();
var scopeProvider = scope.ServiceProvider;

var addRelationExample = scopeProvider.GetRequiredService<AddRelationExample>();
await addRelationExample.ExecuteAsync();

var replaceRelationExample = scopeProvider.GetRequiredService<ReplaceRelationExample>();
await replaceRelationExample.ExecuteAsync();

var removeRelationExample = scopeProvider.GetRequiredService<RemoveRelationExample>();
await removeRelationExample.ExecuteAsync();