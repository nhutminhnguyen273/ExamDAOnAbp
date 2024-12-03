using ExamDAOnAbp.ExamService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.ExamAppServices
{
    public interface IGetListExamsAppService : IApplicationService
    {
        Task<ListResultDto<ExamDto>> GetListAsync();
    }
}
