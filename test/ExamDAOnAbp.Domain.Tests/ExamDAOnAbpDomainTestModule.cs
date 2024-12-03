using Volo.Abp.Modularity;

namespace ExamDAOnAbp;

[DependsOn(
    typeof(ExamDAOnAbpDomainModule),
    typeof(ExamDAOnAbpTestBaseModule)
)]
public class ExamDAOnAbpDomainTestModule : AbpModule
{

}
