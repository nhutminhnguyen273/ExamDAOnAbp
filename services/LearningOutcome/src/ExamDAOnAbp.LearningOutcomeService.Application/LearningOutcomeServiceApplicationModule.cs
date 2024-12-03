using ExamDAOnAbp.CourseService.HttpClients.Courses;
using ExamDAOnAbp.CourseService.Interfaces.HttpClients;
using ExamDAOnAbp.LearningOutcomeService.AppServices.DepartmentAppServices;
using ExamDAOnAbp.LearningOutcomeService.AppServices.OutcomeAppServices;
using ExamDAOnAbp.LearningOutcomeService.AppServices.TrainingProgramAppService;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.OutcomeAppServices;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.TrainingProgramAppServices;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using System;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.LearningOutcomeService;

[DependsOn(
    typeof(LearningOutcomeServiceDomainModule),
    typeof(LearningOutcomeServiceApplicationContractsModule),
    typeof(AbpDddApplicationModule)
    )]
public class LearningOutcomeServiceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<LearningOutcomeServiceApplicationModule>();
        });

        // Department
        context.Services.AddScoped<IGetDepartmentByIdAppService, GetDepartmentByIdAppService>();
        context.Services.AddScoped<IGetListDepartmentsAppService, GetListDepartmentsAppService>();
        context.Services.AddScoped<IFindDepartmentByNameAppService, FindDepartmentByNameAppService>();
        context.Services.AddScoped<IImportDepartmentsFromExcelAppService, ImportDepartmentsFromExcelAppService>();

        // Training Program
        context.Services.AddScoped<IGetTrainingProgramByIdAppService, GetTrainingProgramByIdAppService>();
        context.Services.AddScoped<IGetListTrainingProgramsAppService, GetListTrainingProgramsAppService>();
        context.Services.AddScoped<IImportTrainingProgramsFromExcelAppService, ImportTrainingProgramsFromExcelAppService>();

        // Outcome
        context.Services.AddScoped<IGetOutcomeByIdAppService, GetOutcomeByIdAppService>();
        context.Services.AddScoped<IGetListOutcomesAppService, GetListOutcomesAppService>();
        context.Services.AddScoped<IImportOutcomesFromExcelAppService, ImportOutcomesFromExcelAppService>();

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        context.Services.AddHttpClient<CourseClientService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5005");
        });
    }
}
