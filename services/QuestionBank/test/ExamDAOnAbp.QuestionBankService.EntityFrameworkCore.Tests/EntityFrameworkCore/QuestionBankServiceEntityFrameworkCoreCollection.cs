﻿using Xunit;

namespace ExamDAOnAbp.QuestionBankService.EntityFrameworkCore;

[CollectionDefinition(QuestionBankServiceTestConsts.CollectionDefinitionName)]
public class QuestionBankServiceEntityFrameworkCoreCollection : ICollectionFixture<QuestionBankServiceEntityFrameworkCoreFixture>
{

}
