using Foodway.Config.Bootstrap;
using Foodway.Config.Handlers;

namespace Foodway.Api.StartupConfig;

/// <summary>
///     Startup is a class to simplify the setup services and web application pipeline.
/// </summary>
public class Startup : IAppStartup
{
    private const string CorsPolicy = "CorsPolicy";

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services,
        IWebHostEnvironment environment)
    {
        services.AddDatabaseConfiguration(Configuration, environment);

        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy,
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        services.AddControllers();
        services.AddApiDocsConfiguration();
        services.AddHttpsRedirectionConfiguration(environment);
        services.AddIoCServices();
        services.AddCache();
    }

    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {
        app.UseApiDocsConfiguration();

        app.UseCors(CorsPolicy);
        app.UseCustomHttpsRedirection();
        app.ConfigureExceptionHandler();
        app.MapControllers();

        app.AppUseMigrations();

        app.Run();
    }
}