using ExamDAOnAbp.DataWarehouse.Samples;
using Xunit;

namespace ExamDAOnAbp.DataWarehouse.EntityFrameworkCore.Domains;

[Collection(DataWarehouseTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<DataWarehouseEntityFrameworkCoreTestModule>
{

}
