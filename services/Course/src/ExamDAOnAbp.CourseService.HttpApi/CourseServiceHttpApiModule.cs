using Localization.Resources.AbpUi;
using ExamDAOnAbp.CourseService.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Mvc;

namespace ExamDAOnAbp.CourseService;

[DependsOn(
    typeof(CourseServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule)
    )]
public class CourseServiceHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CourseServiceResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
