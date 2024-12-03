using ExamDAOnAbp.DataWarehouse.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ExamDAOnAbp.DataWarehouse.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class DataWarehouseController : AbpControllerBase
{
    protected DataWarehouseController()
    {
        LocalizationResource = typeof(DataWarehouseResource);
    }
}
