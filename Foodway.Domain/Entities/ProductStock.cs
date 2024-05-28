namespace Foodway.Domain.Entities;

public class ProductStock
{
    public Guid Id { get; set; }
    public required Product Product { get; set; }
    public required Guid ProductId { get; set; }
    public int QuantityInStock { get; set; }

    public bool IsAvailable => QuantityInStock > 0;
}