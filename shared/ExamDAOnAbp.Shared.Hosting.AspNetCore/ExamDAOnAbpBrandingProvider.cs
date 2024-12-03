using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ExamDAOnAbp.Shared.Hosting.AspNetCore
{
    [Dependency(ReplaceServices = true)]
    public class ExamDAOnAbpBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ExamDAOnAbp";
    }
}
