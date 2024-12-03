using Volo.Abp.Modularity;

namespace ExamDAOnAbp;

[DependsOn(
    typeof(ExamDAOnAbpApplicationModule),
    typeof(ExamDAOnAbpDomainTestModule)
)]
public class ExamDAOnAbpApplicationTestModule : AbpModule
{

}
