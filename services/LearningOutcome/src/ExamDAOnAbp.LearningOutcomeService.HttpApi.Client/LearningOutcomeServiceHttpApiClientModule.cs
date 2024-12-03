using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ExamDAOnAbp.LearningOutcomeService;

[DependsOn(
    typeof(LearningOutcomeServiceApplicationContractsModule),
    typeof(AbpHttpClientModule)
)]
public class LearningOutcomeServiceHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "LearningOutcome";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(LearningOutcomeServiceApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<LearningOutcomeServiceHttpApiClientModule>();
        });
    }
}
