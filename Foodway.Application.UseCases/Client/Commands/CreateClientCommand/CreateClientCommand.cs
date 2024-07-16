using Foodway.Shared.Results;
using MediatR;

namespace Foodway.Application.UseCases.Client.Commands.CreateClientCommand;

public class CreateClientCommand : IRequest<string>
{
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
}