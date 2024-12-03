using Volo.Abp.Modularity;

namespace ExamDAOnAbp.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceApplicationModule),
    typeof(AdministrationServiceDomainTestModule)
)]
public class AdministrationServiceApplicationTestModule : AbpModule
{

}
