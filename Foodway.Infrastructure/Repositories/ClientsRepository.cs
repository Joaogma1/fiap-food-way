using Foodway.Domain.Contracts.Repositories;
using Foodway.Domain.Entities;
using Foodway.Infrastructure.Contexts;

namespace Foodway.Infrastructure.Repositories
{
    public class ClientsRepository : Repository<Clients>, IClientsRepository
    {
        public ClientsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
