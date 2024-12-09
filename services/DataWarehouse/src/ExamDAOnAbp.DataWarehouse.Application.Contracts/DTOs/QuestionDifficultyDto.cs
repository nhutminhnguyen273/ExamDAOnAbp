using System;

namespace ExamDAOnAbp.DataWarehouse.DTOs
{
    public class QuestionDifficultyDto
    {
        public Guid QuestionId { get; set; }
        public string DifficultyLevel { get; set; }
    }
}
