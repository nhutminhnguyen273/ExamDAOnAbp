using ExamDAOnAbp.AdministrationService.Samples;
using Xunit;

namespace ExamDAOnAbp.AdministrationService.EntityFrameworkCore.Domains;

[Collection(AdministrationServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AdministrationServiceEntityFrameworkCoreTestModule>
{

}
