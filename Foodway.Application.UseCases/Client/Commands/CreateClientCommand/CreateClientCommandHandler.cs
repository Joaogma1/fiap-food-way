using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Client.Commands.CreateClientCommand;

public class CreateClientCommandHandler : BaseCommandHandler, IRequestHandler<CreateClientCommand,string>
{
    public CreateClientCommandHandler(IDomainNotification notifications) : base(notifications)
    {
    }
    
    public async Task<string> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult("teste");
    }
}