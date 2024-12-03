using ExamDAOnAbp.ExamService.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.StudentAppServices
{
    public interface IImportStudentsFromExcelAppService : IApplicationService
    {
        Task<ListResultDto<StudentDto>> ImportExcelAsync(IFormFile file);
    }
}
