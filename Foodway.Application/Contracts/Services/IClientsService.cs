using Foodway.Domain.QueryFilters;
using Foodway.Domain.Requests.Clients;
using Foodway.Domain.ViewModels.Clients;
using Foodway.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Application.Contracts.Services
{
    public interface IClientsService
    {
        Task<string> CreateAsync(CreateClientRequest req);

        Task<ClientsViewModel?> GetByCPFAsync(string id);
    }
}
