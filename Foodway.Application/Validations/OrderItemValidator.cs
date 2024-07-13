using FluentValidation;
using Foodway.Domain.Requests.Order;
using Foodway.Shared.Validations;

namespace Foodway.Application.Validations;

public class OrderItemValidator : BaseValidator<OrderItem>
{
    public OrderItemValidator()
    {
        RuleFor(item => item.ProductId)
            .NotEmpty().WithMessage("ProductId is required.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
    }
}