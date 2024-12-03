using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ExamDAOnAbp.DataWarehouse.Data;

/* This is used if database provider does't define
 * IDataWarehouseDbSchemaMigrator implementation.
 */
public class NullDataWarehouseDbSchemaMigrator : IDataWarehouseDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
