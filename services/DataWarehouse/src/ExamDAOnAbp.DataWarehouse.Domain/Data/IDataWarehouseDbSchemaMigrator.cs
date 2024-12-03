using System.Threading.Tasks;

namespace ExamDAOnAbp.DataWarehouse.Data;

public interface IDataWarehouseDbSchemaMigrator
{
    Task MigrateAsync();
}
