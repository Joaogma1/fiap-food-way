using Foodway.Shared.Notifications;

namespace Foodway.Application.UseCases;

public abstract class BaseHandler
{
    protected IDomainNotification Notifications;

    public BaseHandler(IDomainNotification notifications)
    {
        Notifications = notifications;
    }
}