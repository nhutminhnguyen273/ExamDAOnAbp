using System;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.QuestionBankService.Entities
{
    public class Answer : AggregateRoot<Guid>
    {
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public Answer() { }

        public Answer(Guid id, string content, bool isCorrect, Guid questionId)
        {
            Id = id;
            Content = content;
            IsCorrect = isCorrect;
            QuestionId = questionId;
        }
    }
}
