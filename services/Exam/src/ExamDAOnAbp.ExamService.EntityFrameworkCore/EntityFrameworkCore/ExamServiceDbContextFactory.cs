using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ExamDAOnAbp.ExamService.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ExamServiceDbContextFactory : IDesignTimeDbContextFactory<ExamServiceDbContext>
{
    public ExamServiceDbContext CreateDbContext(string[] args)
    {
        ExamServiceEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ExamServiceDbContext>()
            .UseSqlServer(configuration.GetConnectionString(ExamServiceDbProperties.ConnectionStringName), b =>
            {
                b.MigrationsHistoryTable("__ExamService_Migrations");
            });

        return new ExamServiceDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}ExamDAOnAbp.ExamService.HttpApi.Host"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
