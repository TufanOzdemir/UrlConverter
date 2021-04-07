using CacheManager.Core;
using System;
using System.Linq;

namespace UrlShortener.Domain.Caching
{
    public class CacheManagerService : ICacheManagerService
    {
        private readonly ICacheManager<object> _cacheManager;

        public CacheManagerService(ICacheManager<object> cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public void Remove(string key)
        {
            _cacheManager.Remove(key);
        }

        public void ClearAll(string regionKey = null)
        {
            if (string.IsNullOrWhiteSpace(regionKey))
            {
                _cacheManager.Clear();
            }
            else
            {
                _cacheManager.ClearRegion(regionKey);
            }
        }

        public int Count(string prefix)
        {
            return _cacheManager.CacheHandles.Count();
        }

        public T GetObject<T>(string key) where T : class
        {
            T result = null;
            if (!string.IsNullOrWhiteSpace(key))
            {
                var cacheObject = _cacheManager.GetCacheItem(key);
                result = (T)cacheObject?.Value;
            }
            return result;
        }

        public T Set<T>(string key, T value) where T : class
        {
            _cacheManager.AddOrUpdate(key, value, (v) => value);
            return value;
        }

        public T Set<T>(string key, T value, TimeSpan absoluteExpiration) where T : class
        {
            return Set(key, value);
        }
    }
}