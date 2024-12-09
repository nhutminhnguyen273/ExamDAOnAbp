using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExamDAOnAbp.DataWarehouse.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using ExamDAOnAbp.Shared.Hosting.Microservices;
using ExamDAOnAbp.Shared.Hosting.AspNetCore;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;

namespace ExamDAOnAbp.DataWarehouse;

[DependsOn(
    typeof(DataWarehouseHttpApiModule),
    typeof(DataWarehouseApplicationModule),
    typeof(DataWarehouseEntityFrameworkCoreModule),
    typeof(ExamDAOnAbpSharedHostingMicroservicesModule)
)]
public class DataWarehouseHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        JwtBearerConfigurationHelper.Configure(context, "DataWarehouse");

        SwaggerConfigurationHelper.ConfigureWithOidc(
            context: context,
            authority: configuration["AuthServer:Authority"]!,
            scopes: ["DataWarehouse"],
            discoveryEndpoint: configuration["AuthServer:MetadataAddress"],
            apiTitle: "Data Warehouse API"
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
        Configure<AbpAntiForgeryOptions>(options => { options.AutoValidate = false; });
        context.Services.AddSignalR();
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
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerWithCustomScriptUI(options =>
        {
            var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Data Warehouse Service API");
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
        });
        app.UseAbpSerilogEnrichers();
        app.UseAuditing();
        app.UseUnitOfWork();
        app.UseConfiguredEndpoints();
    }

    //public override async Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
    //{
    //    await context.ServiceProvider
    //        .GetRequiredService<DataWarehouseDatabaseMigrationChecker>()
    //        .CheckAndApplyDatabaseMigrationsAsync();
    //}
}
