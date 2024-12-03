using ExamDAOnAbp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ExamDAOnAbp.Permissions;

public class ExamDAOnAbpPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ExamDAOnAbpPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ExamDAOnAbpPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ExamDAOnAbpResource>(name);
    }
}
