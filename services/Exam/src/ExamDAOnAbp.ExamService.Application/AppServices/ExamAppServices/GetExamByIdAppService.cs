using ExamDAOnAbp.CourseService.HttpClients.Courses;
using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;
using ExamDAOnAbp.ExamService.Interfaces.ExamAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.ExamService.AppServices.ExamAppServices
{
    public class GetExamByIdAppService : ApplicationService, IGetExamByIdAppService
    {
        private readonly IRepository<Exam, Guid> _examRepository;

        public GetExamByIdAppService(IRepository<Exam, Guid> examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<ExamDto> GetAsync(Guid id)
        {
            var exam = await _examRepository.GetAsync(id);
            return ObjectMapper.Map<Exam, ExamDto>(exam);
        }
    }
}
