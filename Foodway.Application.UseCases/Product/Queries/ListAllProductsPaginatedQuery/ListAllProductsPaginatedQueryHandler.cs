using Foodway.Application.Contracts.Services;
using Foodway.Domain.ViewModels.Product;
using Foodway.Shared.Notifications;
using Foodway.Shared.Pagination;
using MediatR;

namespace Foodway.Application.UseCases.Product.Queries.ListAllProductsPaginatedQuery;

public class ListAllProductsPaginatedQueryHandler : BaseHandler,
    IRequestHandler<ListAllProductsPaginatedQuery, PagedList<ProductViewModel>>
{
    private readonly IProductService _productService;

    public ListAllProductsPaginatedQueryHandler(IDomainNotification notifications, IProductService productService) :
        base(notifications)
    {
        _productService = productService;
    }

    public async Task<PagedList<ProductViewModel>> Handle(ListAllProductsPaginatedQuery query,
        CancellationToken cancellationToken)
    {
        return await _productService.getPagedAsync(query.Filter);
    }
}