using System.Reflection;
using Foodway.Application.UseCases.Auth.Commands.SignInCommand;
using Foodway.Application.UseCases.Client.Commands.CreateClientCommand;
using Foodway.Application.UseCases.Order.Commands.CreateOrderCommand;
using Foodway.Application.UseCases.Product.Commands.CreateProductCommand;
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
            cfg.RegisterServicesFromAssemblies(typeof(CreateProductCommandHandler).GetTypeInfo().Assembly);
            cfg.RegisterServicesFromAssemblies(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
        });
        
        return services;
    }
}