namespace Foodway.Shared.Pagination;

public class Pagination : IPagination
{
    public int PageIndex { get; set; } = 1;

    public int PageSize { get; set; } = 20;

    public string SortType { get; set; } = "asc";
}