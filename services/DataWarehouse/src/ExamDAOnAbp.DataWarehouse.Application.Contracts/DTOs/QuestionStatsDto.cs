using System;

namespace ExamDAOnAbp.DataWarehouse.DTOs
{
    public class QuestionStatsDto
    {
        public Guid QuestionId { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalAnswers { get; set; }
        public float CorrectPercentage { get; set; }
    }
}
