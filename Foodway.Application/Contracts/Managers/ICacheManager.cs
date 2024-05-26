using Foodway.Shared.Enums;

namespace Foodway.Application.Contracts.Managers;

public interface ICacheManager
{
    Task<TItem> SetMemoryCache<TItem>(CacheServiceType serviceType, object key, TItem createItem);
    Task ClearAllCachesAsync();
    Task ClearCacheByType(CacheServiceType serviceType);
    Task<TItem?> GetAsync<TItem>(object key);
}