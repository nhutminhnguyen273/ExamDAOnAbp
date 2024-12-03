using Volo.Abp.Modularity;

namespace ExamDAOnAbp.IdentityService;

[DependsOn(
    typeof(IdentityServiceApplicationModule),
    typeof(IdentityServiceDomainTestModule)
)]
public class IdentityServiceApplicationTestModule : AbpModule
{

}
