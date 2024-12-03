using ExamDAOnAbp.LearningOutcomeService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ExamDAOnAbp.LearningOutcomeService.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class LearningOutcomeServiceController : AbpControllerBase
{
    protected LearningOutcomeServiceController()
    {
        LocalizationResource = typeof(LearningOutcomeServiceResource);
    }
}
