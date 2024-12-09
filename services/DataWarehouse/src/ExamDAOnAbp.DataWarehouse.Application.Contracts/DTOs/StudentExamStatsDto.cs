using System;

namespace ExamDAOnAbp.DataWarehouse.DTOs
{
    public class StudentExamStatsDto
    {
        public Guid StudentId { get; set; }
        public float AverageScore { get; set; }
    }
}
