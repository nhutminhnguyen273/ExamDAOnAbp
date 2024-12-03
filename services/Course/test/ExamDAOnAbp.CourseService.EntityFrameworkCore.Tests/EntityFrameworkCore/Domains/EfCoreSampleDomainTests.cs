using ExamDAOnAbp.CourseService.Samples;
using Xunit;

namespace ExamDAOnAbp.CourseService.EntityFrameworkCore.Domains;

[Collection(CourseServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<CourseServiceEntityFrameworkCoreTestModule>
{

}
