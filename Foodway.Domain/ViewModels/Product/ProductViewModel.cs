using Foodway.Domain.ViewModels.Category;

namespace Foodway.Domain.ViewModels.Product;

public class ProductViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public CategoryViewModel Category { get; set; }
    public ProductStockViewModel Stock { get; set; }
}