using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Auth.Commands.SignInCommand;

public class SignInCommandHandler : BaseCommandHandler, IRequestHandler<SignInCommand,string>
{
    public SignInCommandHandler(IDomainNotification notifications) : base(notifications)
    {
    }
    
    public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult("teste");
    }
}