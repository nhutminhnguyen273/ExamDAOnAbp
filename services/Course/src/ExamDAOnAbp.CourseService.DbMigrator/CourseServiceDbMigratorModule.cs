using ExamDAOnAbp.CourseService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.CourseService.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CourseServiceEntityFrameworkCoreModule),
    typeof(CourseServiceApplicationContractsModule)
    )]
public class CourseServiceDbMigratorModule : AbpModule
{
}
