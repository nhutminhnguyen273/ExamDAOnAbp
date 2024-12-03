using System;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.ExamService.Entities
{
    public class ExamResult : AggregateRoot<Guid>
    {
        public Guid StudentId { get; set; }
        public Guid ExamId { get; set; }
        public Guid ExamPaperId { get; set; }
        public Guid QuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public float Score { get; set; }
        public Exam Exam { get; set; }
        public ExamPaper ExamPaper { get; set; }
        public Student Student { get; set; }

        public ExamResult() { }

        public ExamResult(Guid id, Guid studentId, Guid examId, Guid examPaperId, Guid questionId, bool isCorrect, float score)
        {
            Id = id;
            StudentId = studentId;
            ExamId = examId;
            ExamPaperId = examPaperId;
            QuestionId = questionId;
            IsCorrect = isCorrect;
            Score = score;
        } 
    }
}
