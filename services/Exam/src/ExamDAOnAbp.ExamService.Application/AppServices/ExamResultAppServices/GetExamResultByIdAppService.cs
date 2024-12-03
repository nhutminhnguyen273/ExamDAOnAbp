using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;
using ExamDAOnAbp.ExamService.Interfaces.ExamResultAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.ExamService.AppServices.ExamResultAppServices
{
    public class GetExamResultByIdAppService : ApplicationService, IGetExamResultByIdAppService
    {
        private readonly IRepository<ExamResult, Guid> _examResultRepository;

        public GetExamResultByIdAppService(IRepository<ExamResult, Guid> examResultRepository)
        {
            _examResultRepository = examResultRepository;
        }

        public async Task<ExamResultDto> GetAsync(Guid id)
        {
            var examResult = await _examResultRepository.GetAsync(id);
            return ObjectMapper.Map<ExamResult, ExamResultDto>(examResult);
        }
    }
}
