using Foodway.Application.Contracts.Services;
using Foodway.Domain.ViewModels.Order;
using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Order.Queries.GetOrderByIdQuery;

public class GetOrderByIdQueryHandler : BaseHandler,
    IRequestHandler<GetOrderByIdQuery, OrderViewModel?>
{
    private readonly IOrderService _orderService;

    public GetOrderByIdQueryHandler(IDomainNotification notifications, IOrderService orderService) : base(notifications)
    {
        _orderService = orderService;
    }

    public async Task<OrderViewModel?> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
    {
        return await _orderService.GetByIdAsync(query.Id);
    }
}