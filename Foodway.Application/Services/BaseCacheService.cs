using Foodway.Application.Contracts.Managers;
using Foodway.Shared.Notifications;

namespace Foodway.Application.Services;

public class BaseCacheService : BaseService
{
    protected readonly ICacheManager _cacheManager;

    public BaseCacheService(IDomainNotification notifications, ICacheManager cacheManager) : base(notifications)
    {
        _cacheManager = cacheManager;
    }
}