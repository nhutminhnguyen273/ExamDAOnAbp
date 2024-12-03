using ExamDAOnAbp.QuestionBankService.Samples;
using Xunit;

namespace ExamDAOnAbp.QuestionBankService.EntityFrameworkCore.Applications;

[Collection(QuestionBankServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<QuestionBankServiceEntityFrameworkCoreTestModule>
{

}
