using Foodway.Application.Contracts.Services;
using Foodway.Domain.ViewModels.Order;
using Foodway.Shared.Notifications;
using Foodway.Shared.Pagination;
using MediatR;

namespace Foodway.Application.UseCases.Order.Queries.ListAllOrdersPaginatedQuery;

public class ListAllOrdersPaginatedQueryHandler : BaseHandler,
    IRequestHandler<ListAllOrdersPaginatedQuery, PagedList<OrderViewModel>>
{
    private readonly IOrderService _orderService;

    public ListAllOrdersPaginatedQueryHandler(IDomainNotification notifications, IOrderService orderService) :
        base(notifications)
    {
        _orderService = orderService;
    }

    public Task<PagedList<OrderViewModel>> Handle(ListAllOrdersPaginatedQuery query,
        CancellationToken cancellationToken)
    {
        return _orderService.GetPagedAsync(query.Filter);
    }
}