using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace ExamDAOnAbp.DataWarehouse;

[DependsOn(
    typeof(DataWarehouseDomainSharedModule),
    typeof(AbpObjectExtendingModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpDddApplicationContractsModule)
)]
public class DataWarehouseApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        DataWarehouseDtoExtensions.Configure();
    }
}
