using System.Text.Json.Serialization;
using Foodway.Shared.Enums;

namespace Foodway.Domain.Requests.Order;

public class UpdateOrderStatusRequest
{
    [JsonIgnore] public Guid OrderId { get; set; }

    public OrderStatus OrderStatus { get; set; }
}