using ExamDAOnAbp.DataWarehouse.Interfaces;
using ExamDAOnAbp.ExamService.HttpClients;
using ExamDAOnAbp.QuestionBankService.HttpClients.Questions;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using ExamDAOnAbp.DataWarehouse.AppServices;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using ExamDAOnAbp.QuestionBankService.AppServices.QuestionAppServices;

namespace ExamDAOnAbp.DataWarehouse;

[DependsOn(
    typeof(DataWarehouseDomainModule),
    typeof(DataWarehouseApplicationContractsModule),
    typeof(AbpDddApplicationModule)
    )]
public class DataWarehouseApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<DataWarehouseApplicationModule>();
        });

        context.Services.AddScoped<IDataWarehouseAppService, Data_WarehouseAppService>();

        context.Services.AddTransient<UpdateQuestionDifficulty>();

        context.Services.AddHttpClient<AnswerClientService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5006");
        });
        context.Services.AddHttpClient<QuestionClientService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5006");
        });
        context.Services.AddHttpClient<StudentClientService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5007");
        });
        context.Services.AddHttpClient<ExamClientService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5007");
        });
        context.Services.AddHttpClient<ExamResultClientService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5007");
        });
    }
}
