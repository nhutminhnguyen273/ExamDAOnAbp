using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ExamDAOnAbp.LearningOutcomeService.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class LearningOutcomeServiceDbContextFactory : IDesignTimeDbContextFactory<LearningOutcomeServiceDbContext>
{
    public LearningOutcomeServiceDbContext CreateDbContext(string[] args)
    {
        LearningOutcomeServiceEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<LearningOutcomeServiceDbContext>()
            .UseSqlServer(configuration.GetConnectionString(LearningOutcomeServiceDbProperties.ConnectionStringName), b =>
            {
                b.MigrationsHistoryTable("__LearningOutcomeService_Migrations");
            });

        return new LearningOutcomeServiceDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}ExamDAOnAbp.LearningOutcomeService.HttpApi.Host"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
