using ExamDAOnAbp.LearningOutcomeService.Samples;
using Xunit;

namespace ExamDAOnAbp.LearningOutcomeService.EntityFrameworkCore.Applications;

[Collection(LearningOutcomeServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<LearningOutcomeServiceEntityFrameworkCoreTestModule>
{

}
