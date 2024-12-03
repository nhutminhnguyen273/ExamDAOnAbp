using System;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.CourseService.DTOs
{
    public class ChapterDto : AuditedEntityDto<Guid>
    {
        public string Lesson { get; set; }
        public string Title { get; set; }
        public int NumberOfLessons { get; set; }
        public string CLOs { get; set; }
        public Guid CourseId { get; set; }
    }
}
