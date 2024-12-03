using ExamDAOnAbp.CourseService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ExamDAOnAbp.CourseService.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CourseServiceController : AbpControllerBase
{
    protected CourseServiceController()
    {
        LocalizationResource = typeof(CourseServiceResource);
    }
}
