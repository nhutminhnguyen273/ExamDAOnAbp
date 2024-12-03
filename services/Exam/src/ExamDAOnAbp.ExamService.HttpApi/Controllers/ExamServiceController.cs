using ExamDAOnAbp.ExamService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ExamDAOnAbp.ExamService.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ExamServiceController : AbpControllerBase
{
    protected ExamServiceController()
    {
        LocalizationResource = typeof(ExamServiceResource);
    }
}
