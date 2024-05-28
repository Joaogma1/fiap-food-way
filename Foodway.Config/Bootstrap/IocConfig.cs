using System.Reflection;
using Foodway.Domain.Services;
using Foodway.Infrastructure.Repositories;
using Foodway.Shared.Notifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Foodway.Config.Bootstrap;

/// <summary>
///     Represents a class that provides Inversion of Control configuration for the application.
/// </summary>
public static class IocConfig
{
    /// <summary>
    ///     Adds the necessary IoC services to the application.
    /// </summary>
    /// <param name="services">The IServiceCollection instance to add the services to.</param>
    /// <returns>The modified IServiceCollection instance.</returns>
    public static IServiceCollection AddIoCServices(this IServiceCollection services)
    {
        services.AddSingleton(TimeProvider.System);

        #region Persistence

        services.AddScoped<IDomainNotification, DomainNotification>();
        services.AddRepositories(typeof(CategoryRepository).Assembly);

        #endregion

        services.AddApplicationServices();
        services.AddValidations();

        return services;
    }

    /// <summary>
    ///     Adds repositories to the IServiceCollection using reflection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the repositories to.</param>
    /// <param name="assembly">The assembly containing the repository classes.</param>
    /// <exception cref="InvalidOperationException">Thrown when the interface for a repository class is not found.</exception>
    private static void AddRepositories(this IServiceCollection services, Assembly assembly)
    {
        var repositoryTypes = assembly.GetTypes()
            .Where(type => type is { IsClass: true, IsAbstract: false } && type.Name.EndsWith("Repository"))
            .ToList();

        foreach (var repositoryType in repositoryTypes)
        {
            var interfaceType = repositoryType.GetInterfaces()
                .FirstOrDefault(type => type.Name == $"I{repositoryType.Name}");

            if (interfaceType == null)
                throw new InvalidOperationException($"Interface not found for {repositoryType.Name}.");

            services.AddScoped(interfaceType, repositoryType);
        }
    }

    public static async Task AddDefaultUserAndRoles(this IApplicationBuilder app)
    {
        var scopedFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();

        using (var scope = scopedFactory?.CreateScope())
        {
            var service = scope.ServiceProvider.GetService<ISeedService>();
            await service?.SeedRolesAsync();
            await service?.SeedUsersAsync();
        }
    }
}