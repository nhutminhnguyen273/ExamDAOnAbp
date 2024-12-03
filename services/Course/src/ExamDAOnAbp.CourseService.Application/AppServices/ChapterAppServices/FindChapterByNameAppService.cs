using ExamDAOnAbp.CourseService.DTOs;
using ExamDAOnAbp.CourseService.Entities;
using ExamDAOnAbp.CourseService.Interfaces.ChapterAppServices;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.CourseService.AppServices.ChapterAppServices
{
    public class FindChapterByNameAppService : ApplicationService, IFindChapterByNameAppService
    {
        private readonly IRepository<Chapter, Guid> _chapterRepository;

        public FindChapterByNameAppService(IRepository<Chapter, Guid> chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }

        public async Task<ChapterDto> FindAsync(string name)
        {
            var chapter = await _chapterRepository.FirstOrDefaultAsync(c => c.Title == name);
            return ObjectMapper.Map<Chapter, ChapterDto>(chapter);
        }
    }
}
