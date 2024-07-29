using Foodway.Application.Contracts.Services;
using Foodway.Domain.Requests.Product;
using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Product.Commands.UpdateProductCommand;

public class UpsertProductCommandHandler : BaseHandler, IRequestHandler<UpsertProductCommand, string>
{
    private readonly IProductService _productService;

    public UpsertProductCommandHandler(IDomainNotification notifications, IProductService productService) : base(
        notifications)
    {
        _productService = productService;
    }

    public async Task<string> Handle(UpsertProductCommand request, CancellationToken cancellationToken)
    {
        return await _productService.UpsertAsync(new UpdateProductRequest()
        {
            CategoryId = request.CategoryId,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            Id = request.Id
        });
    }
}