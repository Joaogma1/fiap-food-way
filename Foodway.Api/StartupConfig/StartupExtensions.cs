namespace Foodway.Api.StartupConfig;

public static class StartupExtensions
{
    /// <summary>
    ///     Extends WebApplicationBuilder to make possible use a custom Startup File to configure application.
    /// </summary>
    /// <param name="webAppBuilder"></param>
    /// <typeparam name="TStartup"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder)
        where TStartup : IAppStartup
    {
        if (Activator.CreateInstance(typeof(TStartup), webAppBuilder.Configuration) is not IAppStartup startUp)
            throw new ArgumentException("Startup.cs is invalid");

        startUp.ConfigureServices(webAppBuilder.Services, webAppBuilder.Environment);

        var app = webAppBuilder.Build();
        startUp.Configure(app, app.Environment);
        app.Run();

        return webAppBuilder;
    }
}