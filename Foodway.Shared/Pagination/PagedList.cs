namespace Foodway.Shared.Pagination;

public class PagedList<T>
{
    public PagedList(IEnumerable<T> items, long totalRecords, long pageSize)
    {
        Items = items;
        TotalRecords = totalRecords;
        PageSize = pageSize;
        SetTotalPages(pageSize);
    }

    public IEnumerable<T> Items { get; set; }

    public long TotalPages { get; set; }

    public long TotalRecords { get; set; }

    public long PageSize { get; set; }

    private void SetTotalPages(long pageSize)
    {
        if (TotalRecords > 0) TotalPages = (long)Math.Ceiling(TotalRecords / Convert.ToDouble(pageSize));
    }
}