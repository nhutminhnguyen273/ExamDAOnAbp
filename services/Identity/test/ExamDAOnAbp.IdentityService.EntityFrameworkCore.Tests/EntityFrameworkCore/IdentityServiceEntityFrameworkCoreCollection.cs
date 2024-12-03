using Xunit;

namespace ExamDAOnAbp.IdentityService.EntityFrameworkCore;

[CollectionDefinition(IdentityServiceTestConsts.CollectionDefinitionName)]
public class IdentityServiceEntityFrameworkCoreCollection : ICollectionFixture<IdentityServiceEntityFrameworkCoreFixture>
{

}
