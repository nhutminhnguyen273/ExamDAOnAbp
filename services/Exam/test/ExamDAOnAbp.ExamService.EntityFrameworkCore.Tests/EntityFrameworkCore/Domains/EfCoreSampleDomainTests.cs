using ExamDAOnAbp.ExamService.Samples;
using Xunit;

namespace ExamDAOnAbp.ExamService.EntityFrameworkCore.Domains;

[Collection(ExamServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ExamServiceEntityFrameworkCoreTestModule>
{

}
