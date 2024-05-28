namespace Foodway.Domain.Requests.Order;

public class OrderItem
{
    public Guid ProductId { get; set; }
    
    public int Quantity { get; set; }
    
}