using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;
using ExamDAOnAbp.ExamService.Interfaces.StudentAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.ExamService.AppServices.StudentAppServices
{
    public class GetStudentByIdAppService : ApplicationService, IGetStudentByIdAppService
    {
        private readonly IRepository<Student, Guid> _studentRepository;

        public GetStudentByIdAppService(IRepository<Student, Guid> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDto> GetAsync(Guid id)
        {
            var student = await _studentRepository.GetAsync(id);
            return ObjectMapper.Map<Student, StudentDto>(student);
        }
    }
}
