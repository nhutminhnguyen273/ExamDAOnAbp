using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ExamDAOnAbp.IdentityService;

[DependsOn(
    typeof(IdentityServiceApplicationContractsModule),
    typeof(AbpIdentityHttpApiClientModule)
)]
public class IdentityServiceHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "IdentityService";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(IdentityServiceApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<IdentityServiceHttpApiClientModule>();
        });
    }
}
