using ExamDAOnAbp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ExamDAOnAbpEntityFrameworkCoreModule),
    typeof(ExamDAOnAbpApplicationContractsModule)
    )]
public class ExamDAOnAbpDbMigratorModule : AbpModule
{
}
