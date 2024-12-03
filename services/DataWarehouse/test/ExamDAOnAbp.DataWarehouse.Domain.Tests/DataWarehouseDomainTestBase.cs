using Volo.Abp.Modularity;

namespace ExamDAOnAbp.DataWarehouse;

/* Inherit from this class for your domain layer tests. */
public abstract class DataWarehouseDomainTestBase<TStartupModule> : DataWarehouseTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
