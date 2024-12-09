using ExamDAOnAbp.DataWarehouse.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ExamDAOnAbp.DataWarehouse.Interfaces;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.DataWarehouse.Controllers
{
    [Route("api/data-warehouse")]
    [ApiController]
    public class DataWarehouseController : ControllerBase
    {
        private readonly IDataWarehouseAppService _dataWarehouseAppService;

        public DataWarehouseController(IDataWarehouseAppService dataWarehouseAppService)
        {
            _dataWarehouseAppService = dataWarehouseAppService;
        }

        // Endpoint đồng bộ dữ liệu thi
        [HttpPost("sync-exam-data")]
        public async Task<IActionResult> SyncExamData()
        {
            try
            {
                await _dataWarehouseAppService.SyncExamDataAsync();
                return Ok("Dữ liệu đã được đồng bộ thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Đã xảy ra lỗi khi đồng bộ dữ liệu: {ex.Message}");
            }
        }

        // Endpoint lấy điểm trung bình của sinh viên
        [HttpGet("student-average-scores")]
        public async Task<ActionResult<List<StudentExamStatsDto>>> GetStudentAverageScores()
        {
            try
            {
                var studentStats = await _dataWarehouseAppService.GetStudentAverageScoresAsync();
                return Ok(studentStats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Đã xảy ra lỗi khi lấy điểm sinh viên: {ex.Message}");
            }
        }

        // Endpoint lấy thống kê câu hỏi
        [HttpGet("question-stats")]
        public async Task<ActionResult<List<QuestionStatsDto>>> GetQuestionStats()
        {
            try
            {
                var questionStats = await _dataWarehouseAppService.GetQuestionStatsAsync();
                return Ok(questionStats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Đã xảy ra lỗi khi lấy thống kê câu hỏi: {ex.Message}");
            }
        }

        // API chỉ để lấy danh sách độ khó câu hỏi
        [HttpGet("question-difficulty")]
        public async Task<ActionResult<ListResultDto<QuestionDifficultyDto>>> GetQuestionDifficulty()
        {
            try
            {
                var questionDifficulty = await _dataWarehouseAppService.GetQuestionDifficultyAsync();
                return Ok(questionDifficulty);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Đã xảy ra lỗi khi lấy độ khó câu hỏi: {ex.Message}");
            }
        }
    }
}
