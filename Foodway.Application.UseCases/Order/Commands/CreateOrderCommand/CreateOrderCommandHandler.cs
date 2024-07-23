using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Order.Commands.CreateOrderCommand;

public class CreateOrderCommandHandler : BaseCommandHandler, IRequestHandler<CreateOrderCommand,string>
{
    public CreateOrderCommandHandler(IDomainNotification notifications) : base(notifications)
    {
    }
    
    public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult("teste");
    }
}