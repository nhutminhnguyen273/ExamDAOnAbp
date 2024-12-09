using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ExamDAOnAbp.DataWarehouse;

[DependsOn(
    typeof(DataWarehouseApplicationContractsModule),
    typeof(AbpHttpClientModule)
)]
public class DataWarehouseHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "DataWarehouse";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(DataWarehouseApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<DataWarehouseHttpApiClientModule>();
        });
    }
}
