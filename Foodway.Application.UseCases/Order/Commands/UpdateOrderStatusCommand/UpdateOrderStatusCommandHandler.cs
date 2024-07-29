using Foodway.Application.Contracts.Services;
using Foodway.Domain.Requests.Order;
using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Order.Commands.UpdateOrderStatusCommand;

public class UpdateOrderStatusCommandHandler : BaseHandler, IRequestHandler<UpdateOrderStatusCommand, bool>
{
    private readonly IOrderService _orderService;

    public UpdateOrderStatusCommandHandler(IDomainNotification notifications, IOrderService orderService) : base(
        notifications)
    {
        _orderService = orderService;
    }

    public async Task<bool> Handle(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
    {
        return await _orderService.UpdateOrderStatusAsync(new UpdateOrderStatusRequest()
        {
            OrderStatus = command.OrderStatus,
            OrderId = command.OrderId,
            PaymentStatus = command.PaymentStatus
        });
    }
}