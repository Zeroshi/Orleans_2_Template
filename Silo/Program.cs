using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Remotion.Linq.Clauses;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Silo
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var siloBuilder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .UseDashboard(options => { })
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "Orleans2GettingOrganised";
                })
                .Configure<EndpointOptions>(options =>
                    options.AdvertisedIPAddress = IPAddress.Loopback)
                .ConfigureLogging(logging => logging.AddConsole());

            using (var host = siloBuilder.Build())
            {
                await host.StartAsync();

                Console.ReadLine();
            }
        }
    }
}