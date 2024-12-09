using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.DTOs
{
    public class ExamPaperDto : AuditedEntityDto<Guid>
    {
        public string Code { get; set; }
        public Guid CourseId { get; set; }
        public TimeSpan Time { get; set; }
        public Guid QuestionId { get; set; }
    }
}
