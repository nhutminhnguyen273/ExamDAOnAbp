using ExamDAOnAbp.LearningOutcomeService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.LearningOutcomeService.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LearningOutcomeServiceEntityFrameworkCoreModule),
    typeof(LearningOutcomeServiceApplicationContractsModule)
    )]
public class LearningOutcomeServiceDbMigratorModule : AbpModule
{
}
