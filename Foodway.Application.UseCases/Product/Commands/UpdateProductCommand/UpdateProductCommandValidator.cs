using FluentValidation;
using Foodway.Application.UseCases.Product.Commands.CreateProductCommand;
using Foodway.Shared.Validations;

namespace Foodway.Application.UseCases.Product.Commands.UpdateProductCommand;

public class UpdateProductCommandValidator :
    BaseValidator<UpsertProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x).SetValidator(new CreateProductCommandValidator());
        RuleFor(x => x.Id)
            .Must(id =>
                Guid.TryParse(id.ToString(), out _))
            .When(x => x.Id is not null)
            .WithMessage("Invalid Guid format");
    }
}