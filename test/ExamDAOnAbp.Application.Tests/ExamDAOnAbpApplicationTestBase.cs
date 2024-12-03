using Volo.Abp.Modularity;

namespace ExamDAOnAbp;

public abstract class ExamDAOnAbpApplicationTestBase<TStartupModule> : ExamDAOnAbpTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
