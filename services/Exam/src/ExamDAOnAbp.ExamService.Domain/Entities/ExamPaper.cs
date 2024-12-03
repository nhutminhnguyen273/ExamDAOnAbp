using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.ExamService.Entities
{
    public class ExamPaper : AggregateRoot<Guid>
    {
        public string Code { get; set; }
        public Guid CourseId { get; set; }
        public TimeSpan Time { get; set; }
        public Guid QuestionId { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }

        public ExamPaper() { }

        public ExamPaper(Guid id, string code, Guid courseId, TimeSpan time, Guid questionId)
        {
            Id = id;
            Code = code;
            CourseId = courseId;
            Time = time;
            QuestionId = questionId;
        }
    }
}
