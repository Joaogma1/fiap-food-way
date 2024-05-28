using System.Linq.Expressions;
using Foodway.Domain.Entities;
using Foodway.Domain.QueryFilters;
using Foodway.Shared.Persistence;

namespace Foodway.Domain.Contracts.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Expression<Func<Order, bool>> Where(OrdersFilter filter);
}