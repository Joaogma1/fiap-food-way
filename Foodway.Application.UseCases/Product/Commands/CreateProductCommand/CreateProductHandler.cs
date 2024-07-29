using Foodway.Application.Contracts.Services;
using Foodway.Domain.Requests.Product;
using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Product.Commands.CreateProductCommand;

public class CreateProductHandler : BaseHandler, IRequestHandler<CreateProductCommand, string>
{
    private readonly IProductService _productService;

    public CreateProductHandler(IDomainNotification notifications, IProductService productService) : base(notifications)
    {
        _productService = productService;
    }

    public async Task<string> Handle(CreateProductCommand req, CancellationToken cancellationToken)
    {
        return await _productService.CreateAsync(new CreateProductRequest()
        {
            CategoryId = req.CategoryId,
            Name = req.Name,
            Description = req.Description,
            Price = req.Price,
            Stock = req.Stock
        });
    }
}