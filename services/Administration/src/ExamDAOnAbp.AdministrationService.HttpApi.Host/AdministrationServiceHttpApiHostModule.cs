using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExamDAOnAbp.AdministrationService.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using ExamDAOnAbp.Shared.Hosting.Microservices;
using Volo.Abp.Identity;
using ExamDAOnAbp.AdministrationService.DbMigrations;
using ExamDAOnAbp.Shared.Hosting.AspNetCore;
using System.Threading.Tasks;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace ExamDAOnAbp.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceHttpApiModule),
    typeof(AdministrationServiceApplicationModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(ExamDAOnAbpSharedHostingMicroservicesModule),
    typeof(AbpIdentityHttpApiClientModule)
)]
public class AdministrationServiceHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        JwtBearerConfigurationHelper.Configure(context, "AdministrationService");

        SwaggerConfigurationHelper.ConfigureWithOidc(
            context: context,
            authority: configuration["AuthServer:Authority"]!,
            scopes: ["AdministrationService"],
            discoveryEndpoint: configuration["AuthServer:MetadataAddress"],
            apiTitle: "Administration Service API"
        );

        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]!
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.Trim().RemovePostFix("/"))
                            .ToArray()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        Configure<PermissionManagementOptions>(options => { options.IsDynamicPermissionStoreEnabled = true; });

        Configure<SettingManagementOptions>(options => { options.IsDynamicSettingStoreEnabled = true; });

        // Configure<AbpPermissionOptions>(options =>
        // {
        //     options.ValueProviders.Clear();
        //     options.ValueProviders.Add<UserPermissionValueProvider>();
        //     options.ValueProviders.Add<RolePermissionValueProvider>();
        //     options.ValueProviders.Add<ClientPermissionValueProvider>();
        // });
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
        app.UseCors();
        app.UseAbpRequestLocalization();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAbpClaimsMap();
        app.UseUnitOfWork();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerWithCustomScriptUI(options =>
        {
            var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Administration Service API");
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
        });
        app.UseAbpSerilogEnrichers();
        app.UseAuditing();
        app.UseConfiguredEndpoints();
    }

    public override async Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        await context.ServiceProvider
            .GetRequiredService<AdministrationServiceDatabaseMigrationChecker>()
            .CheckAndApplyDatabaseMigrationsAsync();
    }
}