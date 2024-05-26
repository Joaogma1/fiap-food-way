namespace Foodway.Api.StartupConfig;

public interface IAppStartup
{
    public IConfiguration Configuration { get; }
    void Configure(WebApplication app, IWebHostEnvironment environment);
    void ConfigureServices(IServiceCollection services, IWebHostEnvironment environment);
}