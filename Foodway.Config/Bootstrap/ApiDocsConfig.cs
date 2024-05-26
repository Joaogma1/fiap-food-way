using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Foodway.Config.Bootstrap;

public static class ApiDocsConfig
{
    /// <summary>
    ///     Extension method that add Swagger (Api docs) service configuration.
    /// </summary>
    /// <param name="services">Application service container</param>
    /// <returns>Service container with ApiDocs configured for application</returns>
    public static IServiceCollection AddApiDocsConfiguration(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    /// <summary>
    ///     Extension method for Swagger (Api docs) Web Application configuration.
    /// </summary>
    /// <param name="app">Web application instance used to configure the HTTP pipeline, and routes</param>
    /// <returns>In case of Development environment adds Swagger features and UI</returns>
    public static WebApplication UseApiDocsConfiguration(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return app;

        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}