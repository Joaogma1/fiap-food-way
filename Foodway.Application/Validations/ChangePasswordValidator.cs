using FluentValidation;
using Foodway.Domain.Requests.Auth;
using Foodway.Shared.Validations;

namespace Foodway.Application.Validations;

public class ChangePasswordValidator : BaseValidator<ChangePasswordRequest>
{
    public ChangePasswordValidator()
    {
        RuleFor(r => r.OldPassword)
            .NotEmpty()
            .WithMessage("Password is required");
        
        RuleFor(r => r.NewPassword)
            .NotEmpty()
            .WithMessage("Password is required");

        RuleFor(r => r.NewPasswordConfirmation)
            .NotEmpty()
            .WithMessage("Password is required");

        RuleFor(r => r.NewPasswordConfirmation)
            .Equal(r => r.NewPassword)
            .WithMessage("Passwords must match");
    }
}