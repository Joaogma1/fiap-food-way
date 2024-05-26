using Foodway.Shared.Notifications;

namespace Foodway.Shared.Results;

public class EnvelopResult
{
    public bool Success { get; private set; } = true;
    public IEnumerable<Notification> Errors { get; private set; } = new List<Notification>();

    public static EnvelopResult Ok()
    {
        return new EnvelopResult();
    }

    public static EnvelopResult Fail()
    {
        return new EnvelopResult { Success = false };
    }

    public static EnvelopResult Fail(IEnumerable<Notification> notifications)
    {
        return new EnvelopResult
        {
            Errors = notifications,
            Success = false
        };
    }
}