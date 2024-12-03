using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ExamDAOnAbp.ExamService;

[DependsOn(
    typeof(ExamServiceApplicationContractsModule),
    typeof(AbpHttpClientModule)
)]
public class ExamServiceHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Exam";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ExamServiceApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ExamServiceHttpApiClientModule>();
        });
    }
}
