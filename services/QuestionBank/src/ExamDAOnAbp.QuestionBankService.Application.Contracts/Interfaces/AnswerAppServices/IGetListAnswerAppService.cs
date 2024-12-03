using ExamDAOnAbp.QuestionBankService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.QuestionBankService.Interfaces.AnswerAppServices
{
    public interface IGetListAnswerAppService : IApplicationService
    {
        Task<ListResultDto<AnswerDto>> GetListAsync();
    }
}
