using ExamDAOnAbp.CourseService.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ExamDAOnAbp.CourseService.EntityFrameworkCore;

[ConnectionStringName(CourseServiceDbProperties.ConnectionStringName)]
public class CourseServiceDbContext :
    AbpDbContext<CourseServiceDbContext>
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules
    public DbSet<Course> Courses { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    #endregion

    public CourseServiceDbContext(DbContextOptions<CourseServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Course>(b =>
        {
            b.Property(c => c.Code).HasMaxLength(10);
            b.HasIndex(c => c.Code).IsUnique();
            b.HasIndex(c => c.Name).IsUnique();
        });
    }
}
