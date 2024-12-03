using ExamDAOnAbp.Samples;
using Xunit;

namespace ExamDAOnAbp.EntityFrameworkCore.Domains;

[Collection(ExamDAOnAbpTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ExamDAOnAbpEntityFrameworkCoreTestModule>
{

}
