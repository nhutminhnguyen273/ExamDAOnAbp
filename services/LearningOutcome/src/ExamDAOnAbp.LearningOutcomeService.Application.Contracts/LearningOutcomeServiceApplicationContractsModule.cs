using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace ExamDAOnAbp.LearningOutcomeService;

[DependsOn(
    typeof(LearningOutcomeServiceDomainSharedModule),
    typeof(AbpObjectExtendingModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpDddApplicationContractsModule)
)]
public class LearningOutcomeServiceApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        LearningOutcomeServiceDtoExtensions.Configure();
    }
}
