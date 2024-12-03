using Volo.Abp.Modularity;

namespace ExamDAOnAbp.AdministrationService;

/* Inherit from this class for your domain layer tests. */
public abstract class AdministrationServiceDomainTestBase<TStartupModule> : AdministrationServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
