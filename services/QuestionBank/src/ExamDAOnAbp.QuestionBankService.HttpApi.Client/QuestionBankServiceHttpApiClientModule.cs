using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ExamDAOnAbp.QuestionBankService;

[DependsOn(
    typeof(QuestionBankServiceApplicationContractsModule),
    typeof(AbpHttpClientModule)
)]
public class QuestionBankServiceHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = "QuestionBank";

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(QuestionBankServiceApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<QuestionBankServiceHttpApiClientModule>();
        });
    }
}
