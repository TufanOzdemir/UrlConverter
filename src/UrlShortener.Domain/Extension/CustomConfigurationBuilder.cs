using Microsoft.Extensions.Configuration;
using System.IO;

namespace UrlShortener.Domain.Extension
{
    public static class CustomConfigurationBuilder
    {
        public static IConfiguration ConfigurationBuild(string environmentName, IConfigurationBuilder configurationBuilder = null)
        {
            IConfigurationBuilder builder = configurationBuilder == null ? new ConfigurationBuilder() : configurationBuilder;

            return builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddJsonFile($"App_Config/cache.json", optional: false)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}