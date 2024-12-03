using ExamDAOnAbp.AdministrationService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.AdministrationService.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule)
    )]
public class AdministrationServiceDbMigratorModule : AbpModule
{
}
