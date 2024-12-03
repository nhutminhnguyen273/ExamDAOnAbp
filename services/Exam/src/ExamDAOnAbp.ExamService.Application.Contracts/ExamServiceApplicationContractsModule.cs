using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace ExamDAOnAbp.ExamService;

[DependsOn(
    typeof(ExamServiceDomainSharedModule),
    typeof(AbpObjectExtendingModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpDddApplicationContractsModule)
)]
public class ExamServiceApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        ExamServiceDtoExtensions.Configure();
    }
}
