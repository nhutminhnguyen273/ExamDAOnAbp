using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Entities;
using ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.CourseService.AppServices.ChapterAppServices
{
    public class GetListChapterAppService : ApplicationService, IGetListChaptersAppService
    {
        private readonly IRepository<Chapter, Guid> _chapterRepository;

        public GetListChapterAppService(IRepository<Chapter, Guid> chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        public async Task<ListResultDto<ChapterDto>> GetListAsync()
        {
            var list = await _chapterRepository.GetListAsync();
            return new ListResultDto<ChapterDto>(
                ObjectMapper.Map<List<Chapter>, List<ChapterDto>>(list)
            );
        }
    }
}
