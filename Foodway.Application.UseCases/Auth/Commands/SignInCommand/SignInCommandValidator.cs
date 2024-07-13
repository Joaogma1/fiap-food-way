using FluentValidation;
using Foodway.Shared.Validations;

namespace Foodway.Application.UseCases.Auth.Commands.SignInCommand;

public class SignInCommandValidator : BaseValidator<SignInCommand>
{
    public SignInCommandValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(p => p.Password)
            .NotEmpty();
    }
}