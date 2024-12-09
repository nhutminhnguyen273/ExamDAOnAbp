using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.DataWarehouse.EntityFrameworkCore;

[DependsOn(
    typeof(DataWarehouseDomainModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule)
    )]
public class DataWarehouseEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        DataWarehouseEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<DataWarehouseDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure<DataWarehouseDbContext>(c =>
            {
                c.UseSqlServer(b =>
                {
                    b.MigrationsHistoryTable("__DataWarehouse_Migrations");
                });
            });
        });

    }
}
