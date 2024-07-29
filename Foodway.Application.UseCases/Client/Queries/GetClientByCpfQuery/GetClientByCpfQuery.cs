using Foodway.Domain.ViewModels.Clients;
using MediatR;

namespace Foodway.Application.UseCases.Client.Queries.GetClientByCpfQuery;

public class GetClientByCpfQuery : IRequest<ClientsViewModel?>
{
    public GetClientByCpfQuery(string cpf)
    {
        Cpf = cpf;
    }

    public string Cpf { get; private set; }
}