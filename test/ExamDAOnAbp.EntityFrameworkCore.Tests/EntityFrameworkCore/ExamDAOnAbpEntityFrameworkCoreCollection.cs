using Xunit;

namespace ExamDAOnAbp.EntityFrameworkCore;

[CollectionDefinition(ExamDAOnAbpTestConsts.CollectionDefinitionName)]
public class ExamDAOnAbpEntityFrameworkCoreCollection : ICollectionFixture<ExamDAOnAbpEntityFrameworkCoreFixture>
{

}
