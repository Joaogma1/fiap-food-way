using FluentValidation;
using Foodway.Shared.Validations;

namespace Foodway.Application.UseCases.Product.Commands.CreateProductCommand;

public class CreateProductCommandValidator : BaseValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.Description)
            .NotEmpty();

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .GreaterThan(0);
    }
}