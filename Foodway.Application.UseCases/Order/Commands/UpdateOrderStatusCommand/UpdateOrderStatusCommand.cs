using System.Text.Json.Serialization;
using Foodway.Shared.Enums;
using MediatR;

namespace Foodway.Application.UseCases.Order.Commands.UpdateOrderStatusCommand;

public class UpdateOrderStatusCommand : IRequest<bool>
{
    public UpdateOrderStatusCommand(Guid orderId, OrderStatus orderStatus, PaymentStatus paymentStatus)
    {
        OrderId = orderId;
        OrderStatus = orderStatus;
        PaymentStatus = paymentStatus;
    }

    [JsonIgnore] public Guid OrderId { get; set; }

    public OrderStatus OrderStatus { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}