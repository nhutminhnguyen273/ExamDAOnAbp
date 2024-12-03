using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Entities;
using ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.CourseService.AppServices.ChapterAppServices
{
    public class GetChapterByIdAppService : ApplicationService, IGetChapterByIdAppService
    {
        private readonly IRepository<Chapter, Guid> _chapterRepository;

        public GetChapterByIdAppService(IRepository<Chapter, Guid> chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        public async Task<ChapterDto> GetAsync(Guid id)
        {
            var chapter = await _chapterRepository.GetAsync(id);
            return ObjectMapper.Map<Chapter, ChapterDto>(chapter);
        }
    }
}
