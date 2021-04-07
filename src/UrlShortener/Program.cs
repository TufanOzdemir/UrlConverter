using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;
using System;
using System.Threading;
using UrlShortener.Domain.Extension;

namespace UrlShortener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger logger = null;
            var cancellationTokenSource = new CancellationTokenSource();
            try
            {
                CreateHostBuilder(args, logger).Build().Run();
            }
            catch (Exception ex)
            {
                if (logger != null)
                {
                    logger.Error(ex, "Stopped program because of exception");
                }
                throw;
            }
            finally
            {
                LogManager.Shutdown();
                cancellationTokenSource.Cancel();
            }
        }

        /// <summary>
        /// Test tarafýnda kullanýlabilmesi için ön ayarlý tanýmlandý.
        /// </summary>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder() => CreateHostBuilder(null, null);

        public static IHostBuilder CreateHostBuilder(string[] args, Logger logger)
        {
            var environmentName = Environments.Development;

#if STAGING
            environmentName = Environments.Staging;
#elif RELEASE
            environmentName = Environments.Production;
#endif
            return Host.CreateDefaultBuilder(args)
                .UseEnvironment(environmentName)
                .ConfigureAppConfiguration((hostingContext, builder) =>
                {
                    var configuration = CustomConfigurationBuilder.ConfigurationBuild(environmentName, builder);
                    string configPath = configuration.GetValue<string>("Logging:LogConfigFile");
                    logger = NLogBuilder.ConfigureNLog(configPath).GetCurrentClassLogger();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}