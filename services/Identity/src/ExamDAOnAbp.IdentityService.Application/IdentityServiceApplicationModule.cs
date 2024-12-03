using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.IdentityService;

[DependsOn(
    typeof(IdentityServiceDomainModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpBackgroundJobsModule)
    )]
public class IdentityServiceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<IdentityServiceApplicationModule>();
        });
    }
}
