using Foodway.Application.Contracts.Services;
using Foodway.Domain.ViewModels.Product;
using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Product.Queries.GetProductByIdQuery;

public class GetProductByIdQueryHandler : BaseHandler,
    IRequestHandler<GetProductByIdQuery, ProductViewModel?>
{
    private readonly IProductService _productService;

    public GetProductByIdQueryHandler(IDomainNotification notifications, IProductService productService) : base(
        notifications)
    {
        _productService = productService;
    }

    public async Task<ProductViewModel?> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        return await _productService.GetByIdAsync(query.Id);
    }
}