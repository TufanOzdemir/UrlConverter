using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Domain.Caching
{
    public interface ICacheManagerFactory
    {
        ICacheManagerService GetCacheManagerService(string key);
    }
}
