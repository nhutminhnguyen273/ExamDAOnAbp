using ExamDAOnAbp.ExamService.Localization;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService;

/* Inherit your application services from this class.
 */
public abstract class ExamServiceAppService : ApplicationService
{
    protected ExamServiceAppService()
    {
        LocalizationResource = typeof(ExamServiceResource);
    }
}
