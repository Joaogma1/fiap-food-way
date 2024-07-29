using Foodway.Application.Contracts.Services;
using Foodway.Domain.ViewModels.Order;
using Foodway.Shared.Notifications;
using Foodway.Shared.Pagination;
using MediatR;

namespace Foodway.Application.UseCases.Order.Queries.ListAllOrdersFilteredPaginatedQuery;

public class ListAllOrdersFilteredPaginatedQueryHandler : BaseHandler,
    IRequestHandler<ListAllOrdersFilteredPaginatedQuery, PagedList<OrderViewModel>>
{
    private readonly IOrderService _orderService;

    public ListAllOrdersFilteredPaginatedQueryHandler(IDomainNotification notifications, IOrderService orderService) :
        base(notifications)
    {
        _orderService = orderService;
    }

    public async Task<PagedList<OrderViewModel>> Handle(ListAllOrdersFilteredPaginatedQuery query,
        CancellationToken cancellationToken)
    {
        return await _orderService.GetAllFilteredOrdersAsync(query.PaginationFilter, query.LastOrderId);
    }
}