namespace Foodway.Shared.Pagination;

public interface IPagination
{
    int PageIndex { get; set; }
    int PageSize { get; set; }
    string SortType { get; set; }
}