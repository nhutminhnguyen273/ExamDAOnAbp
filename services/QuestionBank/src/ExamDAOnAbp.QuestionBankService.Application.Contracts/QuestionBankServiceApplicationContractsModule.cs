using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace ExamDAOnAbp.QuestionBankService;

[DependsOn(
    typeof(QuestionBankServiceDomainSharedModule),
    typeof(AbpObjectExtendingModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpDddApplicationContractsModule)
)]
public class QuestionBankServiceApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        QuestionBankServiceDtoExtensions.Configure();
    }
}
