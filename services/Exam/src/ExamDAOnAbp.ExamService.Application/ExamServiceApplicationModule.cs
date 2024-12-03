using ExamDAOnAbp.CourseService.HttpClients.Chapters;
using ExamDAOnAbp.CourseService.HttpClients.Courses;
using ExamDAOnAbp.QuestionBankService.HttpClients.Questions;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using System;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.ExamService;

[DependsOn(
    typeof(ExamServiceDomainModule),
    typeof(ExamServiceApplicationContractsModule),
    typeof(AbpDddApplicationModule)
    )]
public class ExamServiceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ExamServiceApplicationModule>();
        });

        context.Services.AddHttpClient<CourseClientService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5005");
        });

        context.Services.AddHttpClient<QuestionClientService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5006");
        });

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }
}
