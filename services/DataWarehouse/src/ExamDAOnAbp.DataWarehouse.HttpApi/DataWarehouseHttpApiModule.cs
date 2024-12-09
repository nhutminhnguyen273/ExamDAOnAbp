using Localization.Resources.AbpUi;
using ExamDAOnAbp.DataWarehouse.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore.Mvc;

namespace ExamDAOnAbp.DataWarehouse;

[DependsOn(
    typeof(DataWarehouseApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule)
    )]
public class DataWarehouseHttpApiModule : AbpModule
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
                .Get<DataWarehouseResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
