using System;
using System.Collections.Generic;
using System.Text;
using ExamDAOnAbp.Localization;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp;

/* Inherit your application services from this class.
 */
public abstract class ExamDAOnAbpAppService : ApplicationService
{
    protected ExamDAOnAbpAppService()
    {
        LocalizationResource = typeof(ExamDAOnAbpResource);
    }
}
