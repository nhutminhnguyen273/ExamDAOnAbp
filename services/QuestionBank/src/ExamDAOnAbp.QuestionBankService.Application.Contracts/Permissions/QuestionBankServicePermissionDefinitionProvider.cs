using ExamDAOnAbp.QuestionBankService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ExamDAOnAbp.QuestionBankService.Permissions;

public class QuestionBankServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(QuestionBankServicePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(QuestionBankServicePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QuestionBankServiceResource>(name);
    }
}
