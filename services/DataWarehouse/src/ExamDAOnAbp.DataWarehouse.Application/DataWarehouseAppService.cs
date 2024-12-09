using ExamDAOnAbp.DataWarehouse.Localization;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.DataWarehouse;

/* Inherit your application services from this class.
 */
public abstract class DataWarehouseAppService : ApplicationService
{
    protected DataWarehouseAppService()
    {
        LocalizationResource = typeof(DataWarehouseResource);
    }
}
