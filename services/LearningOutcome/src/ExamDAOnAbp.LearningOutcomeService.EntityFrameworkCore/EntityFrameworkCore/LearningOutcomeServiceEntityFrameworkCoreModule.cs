using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.LearningOutcomeService.EntityFrameworkCore;

[DependsOn(
    typeof(LearningOutcomeServiceDomainModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule)
    )]
public class LearningOutcomeServiceEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        LearningOutcomeServiceEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<LearningOutcomeServiceDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure<LearningOutcomeServiceDbContext>(c => 
            {
                c.UseSqlServer(b =>
                {
                    b.MigrationsHistoryTable("__LearningOutcomeService_Migrations");
                });
            });
        });

    }
}
