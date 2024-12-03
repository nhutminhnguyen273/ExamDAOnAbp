using ExamDAOnAbp.QuestionBankService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices
{
    public interface IGetQuestionByIdAppService : IApplicationService
    {
        Task<QuestionDto> GetAsync(Guid id);
    }
}
