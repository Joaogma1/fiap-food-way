using Foodway.Shared.Results;
using MediatR;

namespace Foodway.Application.UseCases.Auth.Commands.SignInCommand;

public class SignInCommand : IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
}