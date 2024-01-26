using System.Reflection;
using EfCore.AuditInterceptor.Application.Common.Identity.Services;
using EfCore.AuditInterceptor.Infrastructure.Common.Identity.Services;
using EfCore.AuditInterceptor.Persistence.DataContexts;
using EfCore.AuditInterceptor.Persistence.Interceptors;
using EfCore.AuditInterceptor.Persistence.Repositories;
using EfCore.AuditInterceptor.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfCore.AuditInterceptor.Api.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        // register automapper
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddRequestContextTools(this WebApplicationBuilder builder)
    {
        // builder.Services.Configure<RequestUserContextSettings>(builder.Configuration.GetSection(nameof(RequestUserContextSettings)));
        // builder.Services.AddHttpContextAccessor();
        // builder.Services.AddScoped<IRequestUserContextProvider, RequestUserContextProvider>()
        //     .AddScoped<IRequestContextProvider, RequestContextProvider>();

        return builder;
    }

    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<UpdateAuditableInterceptor>()
            .AddScoped<UpdatePrimaryKeyInterceptor>();
        
        // .AddScoped<UpdateSoftDeletedInterceptor>();

        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        // register db contexts
        builder.Services.AddDbContext<IdentityDbContext>(
            (provider, options) =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
                
                options.AddInterceptors(provider.GetRequiredService<UpdateAuditableInterceptor>());
                options.AddInterceptors(provider.GetRequiredService<UpdatePrimaryKeyInterceptor>());
            }
        );

        // register repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        // register foundation data access services
        builder.Services.AddScoped<IUserService, UserService>();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();

        return builder;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}