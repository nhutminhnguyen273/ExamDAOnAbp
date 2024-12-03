using ExamDAOnAbp.Shared.Localization;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;

namespace ExamDAOnAbp.Shared.Hosting.AspNetCore;

[DependsOn(
    typeof(ExamDAOnAbpSharedHostingModule),
    typeof(ExamDAOnAbpSharedLocalizationModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)
)]
public class ExamDAOnAbpSharedHostingAspNetCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ExamDAOnAbpSharedHostingAspNetCoreModule>("ExamDAOnAbp.Shared.Hosting.AspNetCore");
        });
    }
}