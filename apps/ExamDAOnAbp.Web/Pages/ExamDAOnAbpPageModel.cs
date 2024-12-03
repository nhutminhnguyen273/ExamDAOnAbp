using ExamDAOnAbp.Shared.Localization.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ExamDAOnAbp.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ExamDAOnAbpPageModel : AbpPageModel
{
    protected ExamDAOnAbpPageModel()
    {
        LocalizationResourceType = typeof(ExamDAOnAbpResource);
    }
}
