using Xunit;

namespace ExamDAOnAbp.CourseService.EntityFrameworkCore;

[CollectionDefinition(CourseServiceTestConsts.CollectionDefinitionName)]
public class CourseServiceEntityFrameworkCoreCollection : ICollectionFixture<CourseServiceEntityFrameworkCoreFixture>
{

}
