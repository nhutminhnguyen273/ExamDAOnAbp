using ExamDAOnAbp.QuestionBankService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.QuestionBankService.Interfaces.AnswerAppServices
{
    public interface IGetAnswerByIdAppService : IApplicationService
    {
        Task<AnswerDto> GetAsync(Guid id);
    }
}
