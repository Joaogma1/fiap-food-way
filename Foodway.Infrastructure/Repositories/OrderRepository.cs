using System.Linq.Expressions;
using Foodway.Domain.Contracts.Repositories;
using Foodway.Domain.Entities;
using Foodway.Domain.QueryFilters;
using Foodway.Infrastructure.Contexts;
using Foodway.Shared.Enums;
using Foodway.Shared.Helpers;

namespace Foodway.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public Expression<Func<Order, bool>> Where(OrdersFilter filter)
    {
        var predicate = PredicateBuilder.True<Order>();

        predicate = string.IsNullOrEmpty(filter.Code)
            ? predicate
            : predicate.And(x => x.OrderCode!.ToLower() == filter.Code.ToLower());

        predicate = filter.PaymentStatus is null
            ? predicate.And(x => x.PaymentStatus == PaymentStatus.Approved)
            : predicate.And(x => x.PaymentStatus == filter.PaymentStatus);

        predicate = filter.OrderStatus is null
            ? predicate.And(x => x.OrderStatus == OrderStatus.ReadyForPickUp)
            : predicate.And(x => x.OrderStatus == filter.OrderStatus);

        predicate = filter.ClientId is null || filter.ClientId == Guid.Empty
            ? predicate
            : predicate.And(x => x.ClientId == filter.ClientId);

        return predicate;
    }

    public Expression<Func<Order, bool>>? Where(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}