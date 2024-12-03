using ExamDAOnAbp.IdentityService.Samples;
using Xunit;

namespace ExamDAOnAbp.IdentityService.EntityFrameworkCore.Domains;

[Collection(IdentityServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<IdentityServiceEntityFrameworkCoreTestModule>
{

}
