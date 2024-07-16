using Foodway.Shared.Notifications;

namespace Foodway.Application.UseCases;

public class BaseCommandHandler
{
    protected IDomainNotification Notifications;
    public BaseCommandHandler(IDomainNotification notifications)
    {
        Notifications = notifications;
    }
}