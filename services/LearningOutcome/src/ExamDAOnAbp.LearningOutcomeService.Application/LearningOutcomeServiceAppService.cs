using ExamDAOnAbp.LearningOutcomeService.Localization;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.LearningOutcomeService;

/* Inherit your application services from this class.
 */
public abstract class LearningOutcomeServiceAppService : ApplicationService
{
    protected LearningOutcomeServiceAppService()
    {
        LocalizationResource = typeof(LearningOutcomeServiceResource);
    }
}
