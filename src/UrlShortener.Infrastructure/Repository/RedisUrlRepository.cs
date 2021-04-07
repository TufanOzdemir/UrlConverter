using UrlShortener.Domain.Caching;
using UrlShortener.Domain.Model.Const;
using UrlShortener.Domain.Port;

namespace UrlShortener.Infrastructure.Repository
{
    public class RedisUrlRepository : IUrlRepository
    {
        private readonly ICacheManagerService _cacheManagerService;
        public RedisUrlRepository(ICacheManagerFactory cacheManagerFactory)
        {
            _cacheManagerService = cacheManagerFactory.GetCacheManagerService(ConstVariables.Caching.CommonCacheConfigurationKey);
        }

        public string Create(string key, string model)
        {
            _cacheManagerService.Set(key, model);
            _cacheManagerService.Set(model, key);
            return key;
        }

        public string Get(string key)
        {
            return _cacheManagerService.GetObject<string>(key);
        }
    }
}