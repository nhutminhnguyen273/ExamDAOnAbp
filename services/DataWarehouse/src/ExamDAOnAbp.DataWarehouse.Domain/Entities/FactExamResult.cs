using System;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.DataWarehouse.Entities
{
    public class FactExamResult : AggregateRoot<Guid>
    {
        public Guid StudentId { get; set; }
        public Guid ExamId { get; set; }
        public Guid ExamPaperId { get; set; }
        public Guid QuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public float Score { get; set; }
        public DimExam Exam { get; set; }
        public DimStudent Student { get; set; }
        public DimQuestion Question { get; set; }

        public FactExamResult() { }

        public FactExamResult(Guid id, Guid studentId, Guid examId, Guid examPaperId, Guid questionId, bool  isCorrect, float score)
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
