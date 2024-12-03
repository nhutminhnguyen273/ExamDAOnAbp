using Volo.Abp.Modularity;

namespace ExamDAOnAbp.AdministrationService;

public abstract class AdministrationServiceApplicationTestBase<TStartupModule> : AdministrationServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
