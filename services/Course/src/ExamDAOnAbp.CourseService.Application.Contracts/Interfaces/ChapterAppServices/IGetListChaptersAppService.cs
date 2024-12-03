using ExamDAOnAbp.CourseService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices
{
    public interface IGetListChaptersAppService : IApplicationService
    {
        Task<ListResultDto<ChapterDto>> GetListAsync();
    }
}
