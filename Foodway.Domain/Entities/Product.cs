namespace Foodway.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public ProductStock Stock { get; set; }
    public IEnumerable<OrderItems> ProductOrders { get; set; } = new List<OrderItems>();
}