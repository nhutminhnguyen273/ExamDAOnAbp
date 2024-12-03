using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ExamDAOnAbp.CourseService;

[DependsOn(
    typeof(CourseServiceApplicationContractsModule),
    typeof(AbpHttpClientModule)
)]
public class CourseServiceHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "Course";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(CourseServiceApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CourseServiceHttpApiClientModule>();
        });
    }
}
