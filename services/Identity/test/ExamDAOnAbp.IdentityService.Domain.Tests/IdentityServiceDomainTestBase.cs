using Volo.Abp.Modularity;

namespace ExamDAOnAbp.IdentityService;

/* Inherit from this class for your domain layer tests. */
public abstract class IdentityServiceDomainTestBase<TStartupModule> : IdentityServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
