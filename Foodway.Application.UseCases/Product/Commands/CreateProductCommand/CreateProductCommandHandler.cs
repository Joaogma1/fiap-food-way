using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Product.Commands.CreateProductCommand;

public class CreateProductCommandHandler : BaseCommandHandler, IRequestHandler<CreateProductCommand,string>
{
    public CreateProductCommandHandler(IDomainNotification notifications) : base(notifications)
    {
    }
    
    public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult("teste");
    }
}