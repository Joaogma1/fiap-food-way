namespace Foodway.Domain.Requests.Order;

public class CreateOrdersRequest
{
    public Guid? ClientId { get; set; }

    public IEnumerable<OrderItem> Items { get; set; } = new List<OrderItem>();
}