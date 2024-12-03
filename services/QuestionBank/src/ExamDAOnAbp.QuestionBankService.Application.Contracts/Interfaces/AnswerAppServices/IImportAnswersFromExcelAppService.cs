using ExamDAOnAbp.QuestionBankService.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.QuestionBankService.Interfaces.AnswerAppServices
{
    public interface IImportAnswersFromExcelAppService : IApplicationService
    {
        Task<ListResultDto<AnswerDto>> ImportExcelAsync(IFormFile file);
    }
}
