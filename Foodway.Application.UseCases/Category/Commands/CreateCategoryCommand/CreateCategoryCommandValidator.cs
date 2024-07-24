using FluentValidation;
using Foodway.Shared.Validations;

namespace Foodway.Application.UseCases.Category.Commands.CreateCategoryCommand;

public class CreateCategoryCommandValidator : BaseValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty();
    }
}