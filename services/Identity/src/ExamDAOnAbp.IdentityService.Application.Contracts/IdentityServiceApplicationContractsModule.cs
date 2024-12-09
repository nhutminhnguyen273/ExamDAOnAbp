using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;

namespace ExamDAOnAbp.IdentityService;

[DependsOn(
    typeof(IdentityServiceDomainSharedModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpObjectExtendingModule)
)]
public class IdentityServiceApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        IdentityServiceDtoExtensions.Configure();
    }
}
