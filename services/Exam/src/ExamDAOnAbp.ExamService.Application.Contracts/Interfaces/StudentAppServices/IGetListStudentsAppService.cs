using ExamDAOnAbp.ExamService.DTOs;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.StudentAppServices
{
    public interface IGetListStudentsAppService : IApplicationService
    {
        Task<ListResultDto<StudentDto>> GetListAsync();
    }
}
