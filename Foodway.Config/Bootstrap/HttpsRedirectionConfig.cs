using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Foodway.Config.Bootstrap;

public static class HttpsRedirectionConfig
{
    /// <summary>
    ///     Extension method that add  Https Redirection service configuration.
    /// </summary>
    /// <param name="services">Application service container.</param>
    /// <param name="environment">IWebHostEnvironment that provides environment information.</param>
    /// <returns>Service container wit https redirection configured for application.</returns>
    public static IServiceCollection AddHttpsRedirectionConfiguration(this IServiceCollection services,
        IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment()) return services;

        services.AddHttpsRedirection(options =>
        {
            options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
            options.HttpsPort = 443;
        });

        return services;
    }

    /// <summary>
    ///     Extension method for Https Redirection Web Application setup configuration.
    /// </summary>
    /// <param name="app">Web application instance used to configure the HTTP pipeline, and routes.</param>
    /// <returns>In case of Development environment adds HTTPS Redirection.</returns>
    public static WebApplication UseCustomHttpsRedirection(this WebApplication app)
    {
        if (app.Environment.IsDevelopment()) return app;

        app.UseHttpsRedirection();
        return app;
    }
}