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
        public static IQueryable<ClientsViewModel> ToViewModel(this IQueryable<Clients> query) => query.Select(clients => new ClientsViewModel
        {
            Id = clients.Id,
            CPF = clients.CPF,
            Name = clients.Name,
            Email = clients.Email
        });

        public static IEnumerable<ClientsViewModel> ToViewModel(this IEnumerable<Clients> query) => query.Select(clients => new ClientsViewModel
        {
            Id = clients.Id,
            CPF = clients.CPF,
            Name = clients.Name,
            Email = clients.Email
        });

        public static ClientsViewModel ToViewModel(this Clients clients) => new ClientsViewModel
        {
            Id = clients.Id,
            CPF = clients.CPF,
            Name = clients.Name,
            Email = clients.Email
        };
    }
}
