using Foodway.Domain.QueryFilters;
using Foodway.Domain.ViewModels.Order;
using Foodway.Shared.Pagination;
using MediatR;

namespace Foodway.Application.UseCases.Order.Queries.ListAllOrdersPaginatedQuery;

public class ListAllOrdersPaginatedQuery : IRequest<PagedList<OrderViewModel>>
{
    public ListAllOrdersPaginatedQuery(OrdersFilter filter)
    {
        Filter = filter;
    }

    public OrdersFilter Filter { get; private set; }
}