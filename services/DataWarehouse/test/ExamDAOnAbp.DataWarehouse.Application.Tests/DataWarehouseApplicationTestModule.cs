using Volo.Abp.Modularity;

namespace ExamDAOnAbp.DataWarehouse;

[DependsOn(
    typeof(DataWarehouseApplicationModule),
    typeof(DataWarehouseDomainTestModule)
)]
public class DataWarehouseApplicationTestModule : AbpModule
{

}
