using System;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.DTOs
{
    public class CreateExamPaper : AuditedEntityDto<Guid>
    {
        public string Code { get; set; }
        public Guid CourseId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public Guid QuestionId { get; set; }
    }
}
