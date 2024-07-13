using Foodway.Config.Pipelines;
using Microsoft.Extensions.DependencyInjection;

namespace Foodway.Config.Bootstrap;

public static class MediatorConfig
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
        });
        
        return services;
    }
}