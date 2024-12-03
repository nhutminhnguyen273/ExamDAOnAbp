using ExamDAOnAbp.DataWarehouse.Samples;
using Xunit;

namespace ExamDAOnAbp.DataWarehouse.EntityFrameworkCore.Applications;

[Collection(DataWarehouseTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<DataWarehouseEntityFrameworkCoreTestModule>
{

}
