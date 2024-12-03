using Microsoft.AspNetCore.Builder;
using ExamDAOnAbp;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();

builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("ExamDAOnAbp.Web.csproj");
await builder.RunAbpModuleAsync<ExamDAOnAbpWebTestModule>(applicationName: "ExamDAOnAbp.Web" );

public partial class Program
{
}
