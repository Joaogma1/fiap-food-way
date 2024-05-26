using Foodway.Application.Contracts.Managers;
using Foodway.Application.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace Foodway.Config.Bootstrap;

public static class CacheConfig
{
    public static IServiceCollection AddCache(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<ICacheManager, CacheManager>();
        return services;
    }
}