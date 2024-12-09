using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.PSO
{
    public interface IPSOAlgorithm : IApplicationService
    {
        Task GenerateExamPaperAsync(Guid courseId, string examCode, TimeSpan examDuration, int numQuestions);
    }
}
