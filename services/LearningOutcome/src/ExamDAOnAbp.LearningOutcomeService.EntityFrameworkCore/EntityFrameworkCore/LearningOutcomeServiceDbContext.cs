using ExamDAOnAbp.LearningOutcomeService.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace ExamDAOnAbp.LearningOutcomeService.EntityFrameworkCore;

[ConnectionStringName(LearningOutcomeServiceDbProperties.ConnectionStringName)]
public class LearningOutcomeServiceDbContext :
    AbpDbContext<LearningOutcomeServiceDbContext>
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules
    public DbSet<Department> Departments { get; set; }
    public DbSet<TrainingProgram> TrainingPrograms { get; set; }
    public DbSet<Outcome> Outcomes { get; set; }
    #endregion

    public LearningOutcomeServiceDbContext(DbContextOptions<LearningOutcomeServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Department>(b =>
        {
            b.Property(d => d.Code).HasMaxLength(10);
            b.HasIndex(d => d.Code).IsUnique();
            b.HasIndex(d => d.Name).IsUnique();
        });

        builder.Entity<TrainingProgram>(b =>
        {
            b.Property(t => t.Code).HasMaxLength(10);
            b.HasIndex(t => t.Code).IsUnique();
        });
    }
}
