﻿using System;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.DataWarehouse.DTOs
{
    public class FactExamResultDto : AuditedEntityDto<Guid>
    {
        public Guid StudentId { get; set; }
        public Guid ExamId { get; set; }
        public Guid ExamPaperId { get; set; }
        public Guid QuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public float Score { get; set; }
    }
}