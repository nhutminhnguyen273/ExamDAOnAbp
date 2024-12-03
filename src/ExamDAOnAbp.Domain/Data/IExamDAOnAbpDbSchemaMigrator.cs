using System.Threading.Tasks;

namespace ExamDAOnAbp.Data;

public interface IExamDAOnAbpDbSchemaMigrator
{
    Task MigrateAsync();
}
