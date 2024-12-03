using Volo.Abp.Modularity;

namespace ExamDAOnAbp.DataWarehouse;

[DependsOn(
    typeof(DataWarehouseDomainModule),
    typeof(DataWarehouseTestBaseModule)
)]
public class DataWarehouseDomainTestModule : AbpModule
{

}
