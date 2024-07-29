using Foodway.Domain.Requests.Clients;
using Foodway.Domain.ViewModels.Clients;

namespace Foodway.Application.Contracts.Services;

public interface IClientsService
{
    Task<string> CreateAsync(CreateClientRequest req);

    Task<ClientsViewModel?> GetByCpfAsync(string cpf);
}