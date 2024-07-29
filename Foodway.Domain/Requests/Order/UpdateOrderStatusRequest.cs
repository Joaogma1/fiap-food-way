using System.Text.Json.Serialization;
using Foodway.Shared.Enums;

namespace Foodway.Domain.Requests.Order;

public class UpdateOrderStatusRequest
{
    public Guid OrderId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}