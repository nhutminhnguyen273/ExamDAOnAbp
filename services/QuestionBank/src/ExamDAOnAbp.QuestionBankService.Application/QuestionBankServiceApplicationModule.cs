using ExamDAOnAbp.CourseService.HttpClients.Chapters;
using ExamDAOnAbp.QuestionBankService.AppServices.AnswerAppServices;
using ExamDAOnAbp.QuestionBankService.AppServices.QuestionAppServices;
using ExamDAOnAbp.QuestionBankService.Interfaces.AnswerAppServices;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using System;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.QuestionBankService;

[DependsOn(
    typeof(QuestionBankServiceDomainModule),
    typeof(QuestionBankServiceApplicationContractsModule),
    typeof(AbpDddApplicationModule)
    )]
public class QuestionBankServiceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<QuestionBankServiceApplicationModule>();
        });

        // Question
        context.Services.AddScoped<IGetQuestionByIdAppService, GetQuestionByIdAppService>();
        context.Services.AddScoped<IGetListQuestionsAppService, GetListQuestionsAppService>();
        context.Services.AddScoped<IFindQuestionByNameAppService, FindQuestionByNameAppService>();
        context.Services.AddScoped<IImportQuestionsFromExcelAppService, ImportQuestionsFromExcelAppService>();

        // Answer
        context.Services.AddScoped<IGetAnswerByIdAppService, GetAnswerByIdAppService>();
        context.Services.AddScoped<IGetListAnswerAppService, GetListAnswersAppService>();
        context.Services.AddScoped<IImportAnswersFromExcelAppService, ImportAnswersFromExcelAppService>();

        context.Services.AddHttpClient<ChapterClientService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5005");
        });

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }
}
