using ExamDAOnAbp.DataWarehouse.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace ExamDAOnAbp.DataWarehouse.EntityFrameworkCore;

[ConnectionStringName(DataWarehouseDbProperties.ConnectionStringName)]
public class DataWarehouseDbContext :
    AbpDbContext<DataWarehouseDbContext>
{
    #region Entities from the modules
    public DbSet<FactExamResult> FactExamResults { get; set; }
    public DbSet<DimExam> DimExams { get; set; }
    public DbSet<DimStudent> DimStudents { get; set; }
    public DbSet<DimQuestion> DimQuestions { get; set; }
    public DbSet<DimAnswer> DimAnswers { get; set; }
    #endregion

    public DataWarehouseDbContext(DbContextOptions<DataWarehouseDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //builder.Entity<FactExamResult>()
        //    .HasOne(result => result.Exam)
        //    .WithMany(exam => exam.ExamResults)
        //    .HasForeignKey(result => result.ExamId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //builder.Entity<FactExamResult>()
        //    .HasOne(result => result.Question)
        //    .WithMany(question => question.ExamResult)
        //    .HasForeignKey(result => result.QuestionId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }
}
