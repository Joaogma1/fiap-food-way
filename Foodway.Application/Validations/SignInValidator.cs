using FluentValidation;
using Foodway.Domain.Requests.Auth;

namespace Foodway.Application.Validations;

public class SignInValidator : BaseValidator<SignInRequest>
{
    public SignInValidator()
    {
        RuleFor(r => r.Email)
            .EmailAddress()
            .NotEmpty()
            .WithMessage("Email is must be a valid value");

        RuleFor(r => r.Password)
            .NotEmpty()
            .WithMessage("Password is required");
    }
}