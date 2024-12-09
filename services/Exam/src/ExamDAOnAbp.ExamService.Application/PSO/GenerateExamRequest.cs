using System;
using System.ComponentModel.DataAnnotations;

namespace ExamDAOnAbp.ExamService.PSO
{
    /// <summary>
    /// Request model for generating an exam paper
    /// </summary>
    public class GenerateExamRequest
    {
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Exam code must be between 1 and 50 characters.")]
        public string ExamCode { get; set; }

        [Required]
        public TimeSpan ExamDuration { get; set; }

        [Required]
        [Range(1, 500, ErrorMessage = "Number of questions must be between 1 and 500.")]
        public int NumQuestions { get; set; }
    }

    /// <summary>
    /// Response model for generating an exam paper
    /// </summary>
    public class GenerateExamResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

}
