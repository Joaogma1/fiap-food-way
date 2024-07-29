using FluentValidation;
using Foodway.Shared.Validations;

namespace Foodway.Application.UseCases.Order.Commands.UpdateOrderStatusCommand;

public class UpdateOrderStatusCommandValidator : BaseValidator<UpdateOrderStatusCommand>
{
    public UpdateOrderStatusCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty()
            .WithMessage("OrderId Parameter Is Required")
            .Must(id =>
                Guid.TryParse(id.ToString(), out _))
            .WithMessage("Invalid Guid format");

        RuleFor(x => x.OrderStatus)
            .IsInEnum()
            .WithMessage("Order Status is invalid");
        RuleFor(x => x.PaymentStatus)
            .IsInEnum()
            .WithMessage("Order Status is invalid");
    }
}