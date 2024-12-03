using ExamDAOnAbp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ExamDAOnAbp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ExamDAOnAbpController : AbpControllerBase
{
    protected ExamDAOnAbpController()
    {
        LocalizationResource = typeof(ExamDAOnAbpResource);
    }
}
