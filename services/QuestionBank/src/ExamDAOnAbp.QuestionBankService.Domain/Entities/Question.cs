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
        public string? DifficultyLevel { get; set; }
        public bool Deleted { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public Question() { }

        public Question(Guid id, string type, string content, Guid chapterId, string difficultyLevel, string clo, bool deleted)
        {
            Id = id;
            Type = type;
            Content = content;
            ChapterId = chapterId;
            DifficultyLevel = difficultyLevel;
            CLO = clo;
            Deleted = deleted;
        }
        public Question(Guid id, string difficultyLevel, string clo) 
        {
            Id = id;
            DifficultyLevel = difficultyLevel;
            CLO= clo;
        }
    }
}
