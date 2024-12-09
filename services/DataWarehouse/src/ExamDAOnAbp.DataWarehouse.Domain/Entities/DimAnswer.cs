using System;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.DataWarehouse.Entities
{
    public class DimAnswer : AggregateRoot<Guid>
    {
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
        public DimQuestion Question { get; set; }

        public DimAnswer() { }

        public DimAnswer(Guid id, string content, bool isCorrect, Guid questionId)
        {
            Id = id;
            Content = content;
            IsCorrect = isCorrect;
            QuestionId = questionId;
        }
    }
}
