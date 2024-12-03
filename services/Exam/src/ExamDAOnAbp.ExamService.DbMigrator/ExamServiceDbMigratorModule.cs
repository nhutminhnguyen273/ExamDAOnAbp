using ExamDAOnAbp.ExamService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.ExamService.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ExamServiceEntityFrameworkCoreModule),
    typeof(ExamServiceApplicationContractsModule)
    )]
public class ExamServiceDbMigratorModule : AbpModule
{
}
