using Foodway.Domain.ViewModels.Order;
using Foodway.Shared.Pagination;
using MediatR;

namespace Foodway.Application.UseCases.Order.Queries.ListAllOrdersFilteredPaginatedQuery;

public class ListAllOrdersFilteredPaginatedQuery : IRequest<PagedList<OrderViewModel>>
{
    public ListAllOrdersFilteredPaginatedQuery(Pagination paginationFilter, int? lastOrderId = null)
    {
        PaginationFilter = paginationFilter;
        LastOrderId = lastOrderId;
    }

    public Pagination PaginationFilter { get; private set; }

    public int? LastOrderId { get; set; }
}