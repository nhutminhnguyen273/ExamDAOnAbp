using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ExamDAOnAbp.Data;

/* This is used if database provider does't define
 * IExamDAOnAbpDbSchemaMigrator implementation.
 */
public class NullExamDAOnAbpDbSchemaMigrator : IExamDAOnAbpDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
