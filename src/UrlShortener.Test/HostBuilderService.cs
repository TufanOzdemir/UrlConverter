using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;

namespace UrlShortener.Test
{
    internal class HostBuilderService : IDisposable
    {
        internal readonly IHostBuilder Host;
        internal readonly TestServer TestServer;

        internal static Lazy<HostBuilderService> Instance = new Lazy<HostBuilderService>(() =>
        {
            return new HostBuilderService();
        });

        private HostBuilderService()
        {
            Host = Program.CreateHostBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseTestServer();
                });
            TestServer = Host.Start().GetTestServer();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
