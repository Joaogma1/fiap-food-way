namespace Foodway.Shared.Notifications;

public class DomainNotification : IDomainNotification
{
    public List<Notification> Notifications { get; private set; } = new();

    public void Handle(string value)
    {
        Notifications.Add(new Notification(value));
    }

    public void Handle(string key, string value)
    {
        if (Notifications.Any(x => x.Key.Equals(key))) return;

        Notifications.Add(new Notification(key, value));
    }

    public void Handle(Notification item)
    {
        if (Notifications.Any(x => x.Key.Equals(item.Key))) return;

        Notifications.Add(item);
    }

    public IEnumerable<Notification> Notify()
    {
        return Notifications;
    }

    public bool HasNotifications()
    {
        return Notifications.Count > 0;
    }

    public void Dispose()
    {
        Notifications = [];
    }
}