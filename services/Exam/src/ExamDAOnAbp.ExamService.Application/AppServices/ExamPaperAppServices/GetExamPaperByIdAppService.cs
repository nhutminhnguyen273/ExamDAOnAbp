using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;
using ExamDAOnAbp.ExamService.Interfaces.ExamPaperAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.ExamService.AppServices.ExamPaperAppServices
{
    public class GetExamPaperByIdAppService : ApplicationService, IGetExamPaperByIdAppService
    {
        private readonly IRepository<ExamPaper, Guid> _examPaperRepository;

        public GetExamPaperByIdAppService(IRepository<ExamPaper, Guid> examPaperRepository)
        {
            _examPaperRepository = examPaperRepository;
        }

        public async Task<ExamPaperDto> GetAsync(Guid id)
        {
            var examPaper = await _examPaperRepository.GetAsync(id);
            return ObjectMapper.Map<ExamPaper, ExamPaperDto>(examPaper);
        }
    }
}
