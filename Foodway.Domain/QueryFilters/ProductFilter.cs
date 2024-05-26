using Foodway.Shared.Pagination;

namespace Foodway.Domain.QueryFilters;

public class ProductFilter : Pagination
{
    public string? Name { get; set; }
    public int? CategoryId { get; set; } 
}