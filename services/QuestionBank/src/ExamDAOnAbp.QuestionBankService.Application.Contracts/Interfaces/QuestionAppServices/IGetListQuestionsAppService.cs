using ExamDAOnAbp.QuestionBankService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices
{
    public interface IGetListQuestionsAppService : IApplicationService
    {
        Task<ListResultDto<QuestionDto>> GetListAsync();
    }
}
