using FluentValidation;
using Foodway.Shared.Validations;

namespace Foodway.Application.UseCases.Product.Queries.GetProductByIdQuery;

public class GetProductByIdQueryValidator : BaseValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id Parameter is required")
            .Must(id => Guid.TryParse(id.ToString(), out _))
            .WithMessage("Invalid Guid format");
    }
}