using ExamDAOnAbp.CourseService.HttpClients.Chapters;
using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Entities;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ExamDAOnAbp.QuestionBankService.AppServices.QuestionAppServices
{
    public class GetListQuestionsByCourseIdAppService : ApplicationService, IGetListQuestionsByCourseIdAppService
    {
        private readonly IRepository<Question, Guid> _questionRepository;
        private readonly ChapterClientService _chapterClientService;

        public GetListQuestionsByCourseIdAppService(IRepository<Question, Guid> questionRepository, ChapterClientService chapterClientService)
        {
            _questionRepository = questionRepository;
            _chapterClientService = chapterClientService;
        }

        public async Task<ListResultDto<QuestionDto>> GetListByCourseAsync(Guid courseId)
        {
            // 1. Lấy danh sách chapters từ ChapterClientService
            var chaptersResult = await _chapterClientService.GetListChapters();
            if (chaptersResult == null || !chaptersResult.Items.Any())
            {
                throw new UserFriendlyException("No chapters found for the specified course.");
            }

            // 2. Lọc các chapters theo CourseId
            var chapterIds = chaptersResult.Items
                .Where(chapter => chapter.CourseId == courseId)
                .Select(chapter => chapter.Id)
                .ToList();

            if (!chapterIds.Any())
            {
                throw new UserFriendlyException("No chapters found for the specified course.");
            }


            // 3. Lấy danh sách câu hỏi từ QuestionRepository
            var questions = await _questionRepository.GetListAsync(q => chapterIds.Contains(q.ChapterId) && !q.Deleted);

            if (!questions.Any())
            {
                return new ListResultDto<QuestionDto>(new List<QuestionDto>());
            }

            return new ListResultDto<QuestionDto>(
                ObjectMapper.Map<List<Question>, List<QuestionDto>>(questions)
            );
        }
    }
}
