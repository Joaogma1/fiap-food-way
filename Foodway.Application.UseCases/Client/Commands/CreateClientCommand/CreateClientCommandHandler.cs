using Foodway.Application.Contracts.Services;
using Foodway.Domain.Requests.Clients;
using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Client.Commands.CreateClientCommand;

public class CreateClientCommandHandler : BaseCommandHandler, IRequestHandler<CreateClientCommand,string>
{

    private readonly IClientsService _clientsService;

    public CreateClientCommandHandler(IDomainNotification notifications, IClientsService clientsService) : base(notifications)
    {
        _clientsService = clientsService;
    }

    public async Task<string> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        return await _clientsService.CreateAsync(new CreateClientRequest() { CPF = request.CPF, Email = request.Email, Name = request.Name });
    }
}