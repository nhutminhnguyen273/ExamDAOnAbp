using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;
using ExamDAOnAbp.ExamService.Interfaces.StudentAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.ExamService.AppServices.StudentAppServices
{
    public class GetListStudentsAppService : ApplicationService, IGetListStudentsAppService
    {
        private readonly IRepository<Student, Guid> _studentRepository;

        public GetListStudentsAppService(IRepository<Student, Guid> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ListResultDto<StudentDto>> GetListAsync()
        {
            var list = await _studentRepository.GetListAsync();
            return new ListResultDto<StudentDto>(
                ObjectMapper.Map<List<Student>, List<StudentDto>>(list)
            );
        }
    }
}
