using Localization.Resources.AbpUi;
using ExamDAOnAbp.AdministrationService.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;

namespace ExamDAOnAbp.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
    )]
public class AdministrationServiceHttpApiModule : AbpModule
{
}
