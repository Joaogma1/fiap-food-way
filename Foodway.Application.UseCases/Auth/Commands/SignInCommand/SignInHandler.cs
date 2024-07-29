using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Auth.Commands.SignInCommand;

public class SignInHandler : BaseHandler, IRequestHandler<SignInCommand, string>
{
    public SignInHandler(IDomainNotification notifications) : base(notifications)
    {
    }

    public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult("teste");
    }
}