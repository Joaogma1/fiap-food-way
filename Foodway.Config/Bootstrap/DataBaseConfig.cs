using Foodway.Infrastructure.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Foodway.Config.Bootstrap;

public static class DataBaseConfig
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        services.AddDbContextPool<AppDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionString,
                c => { c.EnableRetryOnFailure(); });
            if (webHostEnvironment is not null && webHostEnvironment.IsDevelopment())
            {
            options.EnableSensitiveDataLogging();
            }
        });
        return services;
    }

    public static IApplicationBuilder AppUseMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        if (context != null && context.Database.GetPendingMigrations().Any()) context.Database.Migrate();
        return app;
    }
}