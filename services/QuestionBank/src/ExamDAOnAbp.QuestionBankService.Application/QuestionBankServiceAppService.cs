using System;
using System.Collections.Generic;
using System.Text;
using ExamDAOnAbp.QuestionBankService.Localization;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.QuestionBankService;

/* Inherit your application services from this class.
 */
public abstract class QuestionBankServiceAppService : ApplicationService
{
    protected QuestionBankServiceAppService()
    {
        LocalizationResource = typeof(QuestionBankServiceResource);
    }
}
