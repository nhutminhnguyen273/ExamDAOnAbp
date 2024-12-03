using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace ExamDAOnAbp.CourseService;

[DependsOn(
    typeof(CourseServiceDomainSharedModule),
    typeof(AbpObjectExtendingModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpDddApplicationContractsModule)
)]
public class CourseServiceApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        CourseServiceDtoExtensions.Configure();
    }
}
