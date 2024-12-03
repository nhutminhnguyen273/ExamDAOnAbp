using ExamDAOnAbp.CourseService.Samples;
using Xunit;

namespace ExamDAOnAbp.CourseService.EntityFrameworkCore.Applications;

[Collection(CourseServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<CourseServiceEntityFrameworkCoreTestModule>
{

}
