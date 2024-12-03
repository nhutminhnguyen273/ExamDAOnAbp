using Volo.Abp.Modularity;

namespace ExamDAOnAbp.DataWarehouse;

public abstract class DataWarehouseApplicationTestBase<TStartupModule> : DataWarehouseTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
