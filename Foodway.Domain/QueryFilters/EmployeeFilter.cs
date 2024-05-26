using Foodway.Shared.Pagination;

namespace Foodway.Domain.QueryFilters;

public class EmployeeFilter : Pagination
{
    public string? Name { get; set; }
}