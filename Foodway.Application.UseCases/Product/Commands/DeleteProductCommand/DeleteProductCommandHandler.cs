using Foodway.Application.Contracts.Services;
using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Product.Commands.DeleteProductCommand;

public class DeleteProductCommandHandler : BaseHandler,
    IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductService _productService;

    public DeleteProductCommandHandler(IDomainNotification notifications, IProductService productService) : base(
        notifications)
    {
        _productService = productService;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return await _productService.DeleteAsync(request.Id);
    }
}