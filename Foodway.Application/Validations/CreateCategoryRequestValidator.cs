using FluentValidation;
using Foodway.Domain.Requests.Category;
using Foodway.Shared.Validations;

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