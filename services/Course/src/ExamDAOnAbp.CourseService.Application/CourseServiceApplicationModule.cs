using ExamDAOnAbp.CourseService.AppServices.ChapterAppServices;
using ExamDAOnAbp.CourseService.AppServices.CourseAppServices;
using ExamDAOnAbp.CourseService.HttpClients.Courses;
using ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices;
using ExamDAOnAbp.CourseService.Interfaces.CourseAppServices;
using ExamDAOnAbp.CourseService.Interfaces.HttpClients;
using ExamDAOnAbp.LearningOutcomeService.HttpClients.Departments;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using System;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.CourseService;

[DependsOn(
    typeof(CourseServiceDomainModule),
    typeof(CourseServiceApplicationContractsModule),
    typeof(AbpDddApplicationModule)
    )]
public class CourseServiceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CourseServiceApplicationModule>();
        });

        // Course
        context.Services.AddScoped<IGetCourseByIdAppService, GetCourseByIdAppService>();
        context.Services.AddScoped<IGetListCoursesAppService, GetListCoursesAppService>();
        context.Services.AddScoped<IFindCourseByNameAppService, FindCourseByNameAppService>();
        context.Services.AddScoped<IImportCoursesFromExcelAppService, ImportCoursesFromExcelAppService>();

        // Chapter
        context.Services.AddScoped<IGetChapterByIdAppService, GetChapterByIdAppService>();
        context.Services.AddScoped<IGetListChaptersAppService, GetListChapterAppService>();
        context.Services.AddScoped<IFindChapterByNameAppService, FindChapterByNameAppService>();
        context.Services.AddScoped<IImportChaptersFromExcelAppService, ImportChaptersFromExcelAppService>();

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        context.Services.AddHttpClient<DepartmentClientService>(client =>
        {
            client.BaseAddress = new Uri("http://localhost:5004");
        });
    }
}
