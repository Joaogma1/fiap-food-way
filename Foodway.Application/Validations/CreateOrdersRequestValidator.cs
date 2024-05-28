using FluentValidation;
using Foodway.Domain.Requests.Order;

namespace Foodway.Application.Validations;

public class CreateOrdersRequestValidator : BaseValidator<CreateOrdersRequest>
{
    public CreateOrdersRequestValidator()
    {

        RuleFor(request => request.Items)
            .NotEmpty().WithMessage("At least one order item is required.");

        RuleForEach(request => request.Items)
            .SetValidator(new OrderItemValidator());
    }
}