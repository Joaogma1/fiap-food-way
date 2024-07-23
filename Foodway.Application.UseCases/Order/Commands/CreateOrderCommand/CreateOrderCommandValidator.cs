using FluentValidation;
using Foodway.Shared.Validations;

namespace Foodway.Application.UseCases.Order.Commands.CreateOrderCommand;

public class CreateOrderCommandValidator : BaseValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleForEach(order => order.Items)
            .NotEmpty();

        RuleForEach(x => x.Items).ChildRules(order =>
        {
            order.RuleFor(x => x.Quantity).GreaterThan(0);
            order.RuleFor(x => x.ProductId).NotEmpty();
        });
    }
}