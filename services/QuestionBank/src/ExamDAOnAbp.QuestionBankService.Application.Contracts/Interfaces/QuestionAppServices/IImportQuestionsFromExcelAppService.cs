using ExamDAOnAbp.QuestionBankService.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices
{
    public interface IImportQuestionsFromExcelAppService : IApplicationService
    {
        Task<ListResultDto<QuestionDto>> ImportExcelAsync(IFormFile file);
    }
}
