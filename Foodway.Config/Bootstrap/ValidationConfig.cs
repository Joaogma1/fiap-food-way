using FluentValidation;
using Foodway.Application.UseCases.Auth.Commands.SignInCommand;
using Foodway.Application.UseCases.Category.Commands.CreateCategoryCommand;
using Foodway.Application.UseCases.Client.Commands.CreateClientCommand;
using Foodway.Application.UseCases.Order.Commands.CreateOrderCommand;
using Foodway.Application.UseCases.Product.Commands.CreateProductCommand;
using Microsoft.Extensions.DependencyInjection;

namespace Foodway.Config.Bootstrap;

/// <summary>
///     Provides extension methods for adding validation services to an IServiceCollection.
/// </summary>
public static class ValidationConfig
{
    /// <summary>
    ///     Adds validation services to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add the validation services to.</param>
    /// <returns>Returns the modified IServiceCollection with added validation services.</returns>
    public static IServiceCollection AddValidations(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<SignInCommandValidator>();

        return services;
    }
}