using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.QuestionBankService.Entities
{
    public class Question : AggregateRoot<Guid>
    {
        public string Type { get; set; }
        public string Content { get; set; }
        public Guid ChapterId { get; set; }
        public string CLO { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public Question() { }

        public Question(Guid id, string type, string content, Guid chapterId, string clo)
        {
            Id = id;
            Type = type;
            Content = content;
            ChapterId = chapterId;
            CLO = clo;
        }
    }
}
