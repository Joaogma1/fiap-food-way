using Foodway.Domain.QueryFilters;
using Foodway.Domain.ViewModels.Product;
using Foodway.Shared.Pagination;
using MediatR;

namespace Foodway.Application.UseCases.Product.Queries.ListAllProductsPaginatedQuery;

public class ListAllProductsPaginatedQuery : IRequest<PagedList<ProductViewModel>>
{
    public ListAllProductsPaginatedQuery(ProductFilter filter)
    {
        Filter = filter;
    }

    public ProductFilter Filter { get; private set; }
}