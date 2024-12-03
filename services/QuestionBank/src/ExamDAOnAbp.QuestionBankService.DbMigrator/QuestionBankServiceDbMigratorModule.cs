using ExamDAOnAbp.QuestionBankService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.QuestionBankService.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(QuestionBankServiceEntityFrameworkCoreModule),
    typeof(QuestionBankServiceApplicationContractsModule)
    )]
public class QuestionBankServiceDbMigratorModule : AbpModule
{
}
