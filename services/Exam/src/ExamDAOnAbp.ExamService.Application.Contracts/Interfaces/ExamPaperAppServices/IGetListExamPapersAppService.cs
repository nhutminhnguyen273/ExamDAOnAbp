using ExamDAOnAbp.ExamService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.ExamPaperAppServices
{
    public interface IGetListExamPapersAppService : IApplicationService
    {
        Task<ListResultDto<ExamPaperDto>> GetListAsync();
    }
}
