using System.Reflection;
using Foodway.Application.UseCases.Auth.Commands.SignInCommand;
using Foodway.Config.Pipelines;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Foodway.Config.Bootstrap;

public static class MediatorConfig
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        var useCaseAssembly = typeof(SignInCommandHandler).Assembly.GetTypes()
            .Where(type => type is {IsClass: true, IsAbstract: false}
                           && type.Name.EndsWith("Handler")
                           && type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
            .Select(x => x.GetTypeInfo().Assembly).First();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(useCaseAssembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
        });

        return services;
    }
}