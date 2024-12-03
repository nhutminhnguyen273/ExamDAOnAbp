using Xunit;

namespace ExamDAOnAbp.DataWarehouse.EntityFrameworkCore;

[CollectionDefinition(DataWarehouseTestConsts.CollectionDefinitionName)]
public class DataWarehouseEntityFrameworkCoreCollection : ICollectionFixture<DataWarehouseEntityFrameworkCoreFixture>
{

}
