using ExamDAOnAbp.ExamService.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ExamDAOnAbp.ExamService.EntityFrameworkCore;

[ConnectionStringName(ExamServiceDbProperties.ConnectionStringName)]
public class ExamServiceDbContext :
    AbpDbContext<ExamServiceDbContext>
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamPaper> ExamPapers { get; set; }
    public DbSet<ExamResult> ExamResults { get; set; }
    public DbSet<Student> Students { get; set; }
    #endregion

    public ExamServiceDbContext(DbContextOptions<ExamServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Student>(b =>
        {
            b.HasIndex(s => s.Code).IsUnique();
        });
    }
}
