using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ExamDAOnAbp.DataWarehouse.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class DataWarehouseDbContextFactory : IDesignTimeDbContextFactory<DataWarehouseDbContext>
{
    public DataWarehouseDbContext CreateDbContext(string[] args)
    {
        DataWarehouseEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<DataWarehouseDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new DataWarehouseDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ExamDAOnAbp.DataWarehouse.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
