using Microsoft.Extensions.Localization;
using ExamDAOnAbp.DataWarehouse.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ExamDAOnAbp.DataWarehouse;

[Dependency(ReplaceServices = true)]
public class DataWarehouseBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<DataWarehouseResource> _localizer;

    public DataWarehouseBrandingProvider(IStringLocalizer<DataWarehouseResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
