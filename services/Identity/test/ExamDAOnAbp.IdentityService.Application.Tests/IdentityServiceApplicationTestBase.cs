using Volo.Abp.Modularity;

namespace ExamDAOnAbp.IdentityService;

public abstract class IdentityServiceApplicationTestBase<TStartupModule> : IdentityServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
