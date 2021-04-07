using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.Domain.Caching;

namespace UrlShortener.Domain.Extension
{
    public static class CacheExtensions
    {
        /// <summary>
        /// Michaco Cache yapısını ayağa kaldırır.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCacheManagerService(this IServiceCollection services, IConfiguration configuration)
        {
            var nlogConfigPath = configuration.GetValue<string>("Logging:LogConfigFile");
            services.AddLogging(c => c.AddConsole().AddDebug().AddConfiguration(configuration).AddNLog(nlogConfigPath));

            var cacheManagerFactory = new CacheManagerFactory(configuration);
            cacheManagerFactory.Initialize();
            services.AddSingleton<ICacheManagerFactory>(cacheManagerFactory);
            return services;
        }
    }
}