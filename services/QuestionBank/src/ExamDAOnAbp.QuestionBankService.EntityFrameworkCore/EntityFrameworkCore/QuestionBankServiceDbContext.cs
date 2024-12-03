using ExamDAOnAbp.QuestionBankService.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ExamDAOnAbp.QuestionBankService.EntityFrameworkCore;

[ConnectionStringName(QuestionBankServiceDbProperties.ConnectionStringName)]
public class QuestionBankServiceDbContext :
    AbpDbContext<QuestionBankServiceDbContext>
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    #endregion

    public QuestionBankServiceDbContext(DbContextOptions<QuestionBankServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
