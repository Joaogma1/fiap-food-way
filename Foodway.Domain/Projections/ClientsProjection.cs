using Foodway.Domain.Entities;
using Foodway.Domain.ViewModels.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Domain.Projections
{
    public static class ClientsProjection
    {
        public static IQueryable<ClientsViewModel?> ToViewModel(this IQueryable<Client>? query) => (query != null ? query.Select(clients => new ClientsViewModel
        {
            Id = clients.Id,
            CPF = clients.CPF,
            Name = clients.Name,
            Email = clients.Email
        }): null) ?? new EnumerableQuery<ClientsViewModel?>([]);

        public static IEnumerable<ClientsViewModel?> ToViewModel(this IEnumerable<Client>? query) => (query != null ? query.Select(clients => new ClientsViewModel
        {
            Id = clients.Id,
            CPF = clients.CPF,
            Name = clients.Name,
            Email = clients.Email
        }): null) ?? Array.Empty<ClientsViewModel>();

        public static ClientsViewModel? ToViewModel(this Client? clients) => clients != null ? new ClientsViewModel
        {
            Id = clients.Id,
            CPF = clients.CPF,
            Name = clients.Name,
            Email = clients.Email
        }: null;
    }
}
