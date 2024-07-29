using Foodway.Application.Contracts.Services;
using Foodway.Domain.ViewModels.Clients;
using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Client.Queries.GetClientByCpfQuery;

public class GetClientByCpfQueryHandler : BaseHandler, IRequestHandler<GetClientByCpfQuery, ClientsViewModel?>
{
    private readonly IClientsService _clientsService;

    public GetClientByCpfQueryHandler(IDomainNotification notifications, IClientsService clientsService) : base(
        notifications)
    {
        _clientsService = clientsService;
    }

    public async Task<ClientsViewModel?> Handle(GetClientByCpfQuery query, CancellationToken cancellationToken)
    {
        return await _clientsService.GetByCpfAsync(query.Cpf);
    }
}