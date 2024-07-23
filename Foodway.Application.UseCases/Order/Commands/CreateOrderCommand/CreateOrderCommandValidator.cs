using FluentValidation;
using Foodway.Shared.Validations;

namespace Foodway.Application.UseCases.Order.Commands.CreateOrderCommand;

public class CreateOrderCommandValidator : BaseValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(item => item.ProductId)
            .NotEmpty();

        RuleFor(item => item.Quantity)
            .GreaterThan(0);
    }
}