using ExamDAOnAbp.ExamService.DTOs;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ExamDAOnAbp.ExamService.Interfaces.StudentAppServices
{
    public interface IGetStudentByIdAppService : IApplicationService
    {
        Task<StudentDto> GetAsync(Guid id);
    }
}
