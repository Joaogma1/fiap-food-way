using FluentValidation;
using Foodway.Domain.Requests.Category;

namespace Foodway.Application.Validations;

public class CreateCategoryRequestValidator : BaseValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage("Name is required");
    }
}