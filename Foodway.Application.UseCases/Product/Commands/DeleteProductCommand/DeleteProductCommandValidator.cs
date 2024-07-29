using FluentValidation;
using Foodway.Shared.Validations;

namespace Foodway.Application.UseCases.Product.Commands.DeleteProductCommand;

public class DeleteProductCommandValidator : BaseValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Invalid Guid format");
    }
}