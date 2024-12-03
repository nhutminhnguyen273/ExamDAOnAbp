using ExamDAOnAbp.Shared.Hosting.AspNetCore;
using ExamDAOnAbp.Shared.Hosting.Gateways;
using Microsoft.AspNetCore.Rewrite;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace ExamDAOnAbp.WebPublicGateway;

[DependsOn(typeof(ExamDAOnAbpSharedHostingGatewaysModule))]
public class ExamDAOnAbpWebPublicGatewayModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        SwaggerConfigurationHelper.ConfigureWithOidc(
            context: context,
            authority: configuration["AuthServer:Authority"]!,
            scopes:
            [
                /* Phạm vi yêu cầu cho yêu cầu mã ủy quyền và mô tả chỉ dành cho giao diện người dùng swagger */
                "IdentityService", "AdministrationService",
                "LearningOutcomeService", "CourseService",
                "QuestionBankService", "ExamService"
            ],
            apiTitle: "Web Gateway API",
            discoveryEndpoint: configuration["AuthServer:MetadataAddress"]
        );
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseSwaggerUIWithYarp(context);
        app.UseAbpSerilogEnrichers();

        app.UseRewriter(new RewriteOptions()
            // Regex for "", "/" and "" (whitespace)
            .AddRedirect("^(|\\|\\s+)$", "/swagger"));

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapReverseProxy();
        });
    }
}