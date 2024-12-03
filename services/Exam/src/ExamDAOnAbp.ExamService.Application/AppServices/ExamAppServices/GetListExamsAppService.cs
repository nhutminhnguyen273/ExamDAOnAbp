using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Entities;
using ExamDAOnAbp.ExamService.Interfaces.ExamAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.ExamService.AppServices.ExamAppServices
{
    public class GetListExamsAppService : ApplicationService, IGetListExamsAppService
    {
        private readonly IRepository<Exam, Guid> _examRepository;

        public GetListExamsAppService(IRepository<Exam, Guid> examRepository)
        {
            _examRepository = examRepository;
        }
        public async Task<ListResultDto<ExamDto>> GetListAsync()
        {
            var list = await _examRepository.GetListAsync();
            return new ListResultDto<ExamDto>(
                ObjectMapper.Map<List<Exam>, List<ExamDto>>(list)
            );
        }
    }
}
