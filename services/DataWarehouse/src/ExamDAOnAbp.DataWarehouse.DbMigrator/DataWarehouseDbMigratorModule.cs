using ExamDAOnAbp.DataWarehouse.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.DataWarehouse.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DataWarehouseEntityFrameworkCoreModule),
    typeof(DataWarehouseApplicationContractsModule)
    )]
public class DataWarehouseDbMigratorModule : AbpModule
{
}
