using Localization.Resources.AbpUi;
using ExamDAOnAbp.QuestionBankService.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Mvc;

namespace ExamDAOnAbp.QuestionBankService;

[DependsOn(
    typeof(QuestionBankServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule)
    )]
public class QuestionBankServiceHttpApiModule : AbpModule
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
                .Get<QuestionBankServiceResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
