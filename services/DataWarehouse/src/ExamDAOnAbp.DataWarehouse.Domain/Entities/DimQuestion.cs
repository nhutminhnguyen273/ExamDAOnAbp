using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace ExamDAOnAbp.DataWarehouse.Entities
{
    public class DimQuestion : AggregateRoot<Guid>
    {
        public string Type { get; set; }
        public string Content { get; set; }
        public Guid ChapterId { get; set; }
        public string CLO { get; set; }
        public string? DifficultyLevel { get; set; }
        public ICollection<DimAnswer> Answers { get; set; }
        public ICollection<FactExamResult> ExamResult { get; set; }

        public DimQuestion() { }

        public DimQuestion(Guid id, string type, string content, Guid chapterId, string clo, string difficultyLevel) 
        {
            Id = id;
            Type = type;
            Content = content;
            ChapterId = chapterId;
            CLO = clo;
            DifficultyLevel = difficultyLevel;
        }
    }
}
