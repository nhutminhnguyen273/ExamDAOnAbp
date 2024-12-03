using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExamDAOnAbp.DataWarehouse.Data;
using Volo.Abp.DependencyInjection;

namespace ExamDAOnAbp.DataWarehouse.EntityFrameworkCore;

public class EntityFrameworkCoreDataWarehouseDbSchemaMigrator
    : IDataWarehouseDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreDataWarehouseDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the DataWarehouseDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<DataWarehouseDbContext>()
            .Database
            .MigrateAsync();
    }
}
