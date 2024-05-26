using Foodway.Application.Contracts.Managers;
using Foodway.Shared.Enums;
using Foodway.Shared.Extensions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace Foodway.Application.Managers;

/// <summary>
///     Manages caching functionality using an IMemoryCache implementation.
/// </summary>
public class CacheManager : ICacheManager
{
    private readonly IList<(CacheServiceType Type, string Key)> _caches;
    private readonly IMemoryCache _memoryCache;
    private CancellationTokenSource _cacheTokenSource;

    public CacheManager(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
        _cacheTokenSource = new CancellationTokenSource();
        _caches = new List<(CacheServiceType Type, string Key)>();
    }

    /// <summary>
    ///     Sets an item in the memory cache.
    /// </summary>
    /// <typeparam name="TItem">The type of the cached item.</typeparam>
    /// <param name="serviceType">The type of the cache service.</param>
    /// <param name="key">The key of the cached item.</param>
    /// <param name="cachedItem">The cached item.</param>
    /// <returns>A asynchronous operation with Cached Value .</returns>
    public async Task<TItem> SetMemoryCache<TItem>(CacheServiceType serviceType, object key, TItem cachedItem)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .AddExpirationToken(new CancellationChangeToken(_cacheTokenSource.Token))
            .SetSlidingExpiration(TimeSpan.FromMinutes(5));
        var jsonKey = key.ToJson().ToLowerInvariant();
        var cacheEntry = new ValueTuple<CacheServiceType, string>(serviceType, jsonKey);

        _caches.Add(cacheEntry);

        _memoryCache.Set(cacheEntry, cachedItem, cacheEntryOptions);

        return await Task.FromResult(cachedItem);
    }

    /// <summary>
    ///     Clears all caches asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task ClearAllCachesAsync()
    {
        await _cacheTokenSource.CancelAsync();
        _cacheTokenSource.Dispose();
        _cacheTokenSource = new CancellationTokenSource();
    }

    /// <summary>
    ///     Clears the cache by a specified service type.
    /// </summary>
    /// <param name="serviceType">The type of the cache service.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task ClearCacheByType(CacheServiceType serviceType)
    {
        var entries = _caches.Where(c => c.Type == serviceType);
        foreach (var cacheKey in entries) _memoryCache.Remove(cacheKey);
        await Task.CompletedTask;
    }

    /// <summary>
    ///     Retrieves an item asynchronously from the cache with the specified key.
    /// </summary>
    /// <typeparam name="TItem">The type of the item to retrieve from the cache.</typeparam>
    /// <param name="key">The key used to identify the item in the cache.</param>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains the retrieved item from the cache, or
    ///     <c>null</c> if the item does not exist in the cache.
    /// </returns>
    public Task<TItem?> GetAsync<TItem>(object key)
    {
        var jsonKey = key.ToJson().ToLowerInvariant();
        var cacheKey = _caches.FirstOrDefault(c => string.Equals(c.Key, jsonKey));
        _memoryCache.TryGetValue(cacheKey, out TItem? cacheEntry);
        return Task.FromResult(cacheEntry);
    }
}