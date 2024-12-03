using ExamDAOnAbp.QuestionBankService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices
{
    public interface IFindQuestionByNameAppService : IApplicationService
    {
        Task<QuestionDto> FindAsync(string name);
    }
}
