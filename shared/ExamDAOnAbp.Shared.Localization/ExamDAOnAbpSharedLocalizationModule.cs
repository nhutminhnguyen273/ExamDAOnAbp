using ExamDAOnAbp.Shared.Localization.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace ExamDAOnAbp.Shared.Localization;

[DependsOn(typeof(AbpValidationModule))]
public class ExamDAOnAbpSharedLocalizationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ExamDAOnAbpSharedLocalizationModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<ExamDAOnAbpResource>("en")
                .AddBaseTypes(
                    typeof(AbpValidationResource)
                ).AddVirtualJson("/Localization/ExamDAOnAbp");

            options.DefaultResourceType = typeof(ExamDAOnAbpResource);
        });
    }
}
