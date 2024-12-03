using Xunit;

namespace ExamDAOnAbp.ExamService.EntityFrameworkCore;

[CollectionDefinition(ExamServiceTestConsts.CollectionDefinitionName)]
public class ExamServiceEntityFrameworkCoreCollection : ICollectionFixture<ExamServiceEntityFrameworkCoreFixture>
{

}
