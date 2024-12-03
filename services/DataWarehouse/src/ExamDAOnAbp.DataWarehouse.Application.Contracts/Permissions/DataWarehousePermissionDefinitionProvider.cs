using ExamDAOnAbp.DataWarehouse.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ExamDAOnAbp.DataWarehouse.Permissions;

public class DataWarehousePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DataWarehousePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(DataWarehousePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DataWarehouseResource>(name);
    }
}
