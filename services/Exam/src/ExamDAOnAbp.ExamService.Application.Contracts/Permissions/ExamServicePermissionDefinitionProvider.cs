using ExamDAOnAbp.ExamService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ExamDAOnAbp.ExamService.Permissions;

public class ExamServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ExamServicePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ExamServicePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ExamServiceResource>(name);
    }
}
