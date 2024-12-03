using Volo.Abp.Settings;

namespace ExamDAOnAbp.Settings;

public class ExamDAOnAbpSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ExamDAOnAbpSettings.MySetting1));
    }
}
