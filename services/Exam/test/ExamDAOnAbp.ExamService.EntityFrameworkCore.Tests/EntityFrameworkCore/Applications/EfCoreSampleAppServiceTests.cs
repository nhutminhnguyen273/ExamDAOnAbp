using ExamDAOnAbp.ExamService.Samples;
using Xunit;

namespace ExamDAOnAbp.ExamService.EntityFrameworkCore.Applications;

[Collection(ExamServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ExamServiceEntityFrameworkCoreTestModule>
{

}
