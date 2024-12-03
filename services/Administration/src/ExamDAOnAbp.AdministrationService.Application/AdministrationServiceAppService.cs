using System;
using System.Collections.Generic;
using System.Text;
using ExamDAOnAbp.AdministrationService.Localization;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.AdministrationService;

/* Inherit your application services from this class.
 */
public abstract class AdministrationServiceAppService : ApplicationService
{
    protected AdministrationServiceAppService()
    {
        LocalizationResource = typeof(AdministrationServiceResource);
    }
}
