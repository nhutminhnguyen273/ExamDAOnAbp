using ExamDAOnAbp.QuestionBankService.Samples;
using Xunit;

namespace ExamDAOnAbp.QuestionBankService.EntityFrameworkCore.Domains;

[Collection(QuestionBankServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<QuestionBankServiceEntityFrameworkCoreTestModule>
{

}
