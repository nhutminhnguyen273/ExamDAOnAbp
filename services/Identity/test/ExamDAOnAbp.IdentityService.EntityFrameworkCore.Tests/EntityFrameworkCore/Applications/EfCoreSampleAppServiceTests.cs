using ExamDAOnAbp.IdentityService.Samples;
using Xunit;

namespace ExamDAOnAbp.IdentityService.EntityFrameworkCore.Applications;

[Collection(IdentityServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<IdentityServiceEntityFrameworkCoreTestModule>
{

}
