using FluentValidation;
using Foodway.Shared.Validations;

namespace Foodway.Application.UseCases.Client.Commands.CreateClientCommand;

public class CreateClientCommandValidator : BaseValidator<CreateClientCommand>
{
    public CreateClientCommandValidator()
    {
        RuleFor(x => x.CPF)
            .NotEmpty();

        RuleFor(x => x.CPF)
            .MinimumLength(10)
            .MaximumLength(11);

        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotEmpty();
    }
}