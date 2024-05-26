using Foodway.Application.Contracts.Services;
using Foodway.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Foodway.Config.Bootstrap;

public static class ApplicationServicesConfig
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}