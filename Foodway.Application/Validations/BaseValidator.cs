using FluentValidation;
using FluentValidation.Results;

namespace Foodway.Application.Validations;

public abstract class BaseValidator<T> : AbstractValidator<T>
{
    protected override bool PreValidate(ValidationContext<T> context, ValidationResult result)
    {
        if (context.InstanceToValidate != null) return true;

        result.Errors.Add(new ValidationFailure("", "Please ensure a data is being sent correctly."));
        return false;
    }
}