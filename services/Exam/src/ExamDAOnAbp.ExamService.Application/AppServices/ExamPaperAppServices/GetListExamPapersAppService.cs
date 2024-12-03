using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;
using ExamDAOnAbp.ExamService.Interfaces.ExamPaperAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.ExamService.AppServices.ExamPaperAppServices
{
    public class GetListExamPapersAppService : ApplicationService, IGetListExamPapersAppService
    {
        private readonly IRepository<ExamPaper, Guid> _examPaperRepository;

        public GetListExamPapersAppService(IRepository<ExamPaper, Guid> examPaperRepository)
        {
            _examPaperRepository = examPaperRepository;
        }

        public async Task<ListResultDto<ExamPaperDto>> GetListAsync()
        {
            var list = await _examPaperRepository.GetListAsync();
            return new ListResultDto<ExamPaperDto>(
                ObjectMapper.Map<List<ExamPaper>, List<ExamPaperDto>>(list)
            );
        }
    }
}
