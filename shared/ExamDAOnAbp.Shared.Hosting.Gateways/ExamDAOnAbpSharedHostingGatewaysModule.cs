using ExamDAOnAbp.Shared.Hosting.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.Shared.Hosting.Gateways
{
    [DependsOn(typeof(ExamDAOnAbpSharedHostingAspNetCoreModule))]
    public class ExamDAOnAbpSharedHostingGatewaysModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.AddHttpForwarderWithServiceDiscovery();

            context.Services.AddReverseProxy()
                .LoadFromConfig(configuration.GetSection("ReverseProxy"))
                .AddServiceDiscoveryDestinationResolver();
        }
    }
}
