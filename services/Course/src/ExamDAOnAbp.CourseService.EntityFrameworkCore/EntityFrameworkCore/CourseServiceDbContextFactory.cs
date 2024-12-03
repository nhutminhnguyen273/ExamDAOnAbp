using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ExamDAOnAbp.CourseService.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class CourseServiceDbContextFactory : IDesignTimeDbContextFactory<CourseServiceDbContext>
{
    public CourseServiceDbContext CreateDbContext(string[] args)
    {
        CourseServiceEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CourseServiceDbContext>()
            .UseSqlServer(configuration.GetConnectionString(CourseServiceDbProperties.ConnectionStringName), b =>
            {
                b.MigrationsHistoryTable("__CourseService_Migrations");
            });

        return new CourseServiceDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}ExamDAOnAbp.CourseService.HttpApi.Host"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
