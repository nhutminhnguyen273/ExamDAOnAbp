using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;
using ExamDAOnAbp.ExamService.Interfaces.ExamResultAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.ExamService.AppServices.ExamResultAppServices
{
    public class GetListExamResultsAppService : ApplicationService, IGetListExamResultsAppService
    {
        private readonly IRepository<ExamResult, Guid> _examResultRepository;

        public GetListExamResultsAppService(IRepository<ExamResult, Guid> examResultRepository)
        {
            _examResultRepository = examResultRepository;
        }

        public async Task<ListResultDto<ExamResultDto>> GetListAsync()
        {
            var list = await _examResultRepository.GetListAsync();
            return new ListResultDto<ExamResultDto>(
                ObjectMapper.Map<List<ExamResult>, List<ExamResultDto>>(list)
            );
        }
    }
}
