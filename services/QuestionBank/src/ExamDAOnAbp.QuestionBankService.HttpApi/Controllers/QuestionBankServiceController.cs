using ExamDAOnAbp.QuestionBankService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ExamDAOnAbp.QuestionBankService.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class QuestionBankServiceController : AbpControllerBase
{
    protected QuestionBankServiceController()
    {
        LocalizationResource = typeof(QuestionBankServiceResource);
    }
}
