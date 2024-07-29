using Foodway.Application.Contracts.Services;
using Foodway.Domain.Requests.Order;
using Foodway.Shared.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Foodway.Application.UseCases.Order.Commands.CreateOrderCommand;

public class CreateOrderHandler : BaseHandler, IRequestHandler<CreateOrderCommand, string>
{
    private IOrderService _orderService;

    public CreateOrderHandler(IDomainNotification notifications, IOrderService orderService) : base(notifications)
    {
        _orderService = orderService;
    }

    public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        return await _orderService.CreateAsync(new CreateOrdersRequest()
            { ClientId = request.ClientId, Items = request.Items });
    }
}