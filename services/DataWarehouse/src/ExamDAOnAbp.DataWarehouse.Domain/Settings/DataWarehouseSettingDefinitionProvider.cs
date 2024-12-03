using Volo.Abp.Settings;

namespace ExamDAOnAbp.DataWarehouse.Settings;

public class DataWarehouseSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(DataWarehouseSettings.MySetting1));
    }
}
