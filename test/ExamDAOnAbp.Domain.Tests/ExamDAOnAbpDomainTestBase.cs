using Volo.Abp.Modularity;

namespace ExamDAOnAbp;

/* Inherit from this class for your domain layer tests. */
public abstract class ExamDAOnAbpDomainTestBase<TStartupModule> : ExamDAOnAbpTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
