using Localization.Resources.AbpUi;
using ExamDAOnAbp.LearningOutcomeService.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Mvc;

namespace ExamDAOnAbp.LearningOutcomeService;

[DependsOn(
    typeof(LearningOutcomeServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule)
    )]
public class LearningOutcomeServiceHttpApiModule : AbpModule
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
                .Get<LearningOutcomeServiceResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
