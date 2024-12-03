using ExamDAOnAbp.Samples;
using Xunit;

namespace ExamDAOnAbp.EntityFrameworkCore.Applications;

[Collection(ExamDAOnAbpTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ExamDAOnAbpEntityFrameworkCoreTestModule>
{

}
