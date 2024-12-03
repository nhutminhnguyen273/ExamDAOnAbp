using ExamDAOnAbp.AdministrationService.Samples;
using Xunit;

namespace ExamDAOnAbp.AdministrationService.EntityFrameworkCore.Applications;

[Collection(AdministrationServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AdministrationServiceEntityFrameworkCoreTestModule>
{

}
