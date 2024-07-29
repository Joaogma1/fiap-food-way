using FluentValidation;
using Foodway.Shared.Validations;

namespace Foodway.Application.UseCases.Order.Queries.GetOrderByIdQuery;

public class GetOrderByIdQueryValidator : BaseValidator<GetOrderByIdQuery>
{
    public GetOrderByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id Parameter is required")
            .Must(id => Guid.TryParse(id.ToString(), out _))
            .WithMessage("Invalid Guid format");
    }
}