using System.Reflection;
using Foodway.Application.UseCases.Auth.Commands.SignInCommand;
using Foodway.Application.UseCases.Client.Commands.CreateClientCommand;
using Foodway.Config.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Foodway.Config.Bootstrap;

public static class MediatorConfig
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(SignInCommandHandler).GetTypeInfo().Assembly);
            cfg.RegisterServicesFromAssemblies(typeof(CreateClientCommandHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
        });
        
        return services;
    }
}