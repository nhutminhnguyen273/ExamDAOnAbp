using ExamDAOnAbp.LearningOutcomeService.Samples;
using Xunit;

namespace ExamDAOnAbp.LearningOutcomeService.EntityFrameworkCore.Domains;

[Collection(LearningOutcomeServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<LearningOutcomeServiceEntityFrameworkCoreTestModule>
{

}
