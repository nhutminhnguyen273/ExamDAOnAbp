using ExamDAOnAbp.ExamService.PSO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Volo.Abp;
using ExamDAOnAbp.ExamService.Interfaces.PSO;

namespace ExamDAOnAbp.ExamService.Controllers.ExamPaperControllers
{
    [Route("api/exam-papers/generate")]
    [ApiController]
    public class GenerateExamPaperController : ControllerBase
    {
        private readonly IPSOAlgorithm _psoAlgorithm;

        public GenerateExamPaperController(IPSOAlgorithm psoAlgorithm)
        {
            _psoAlgorithm = psoAlgorithm;
        }

        /// <summary>
        /// API to generate an exam paper
        /// </summary>
        /// <param name="request">Request model containing necessary parameters</param>
        /// <returns>ActionResult with the result</returns>
        [HttpPost]
        public async Task<IActionResult> GenerateExamPaper([FromBody] GenerateExamRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _psoAlgorithm.GenerateExamPaperAsync(
                    request.CourseId,
                    request.ExamCode,
                    request.ExamDuration,
                    request.NumQuestions
                );

                return Ok(new GenerateExamResponse
                {
                    Success = true,
                    Message = "Exam paper generated successfully."
                });
            }
            catch (UserFriendlyException ex)
            {
                return BadRequest(new GenerateExamResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                // Log exception (optional)
                return StatusCode(500, new GenerateExamResponse
                {
                    Success = false,
                    Message = "An unexpected error occurred while generating the exam paper."
                });
            }
        }
    }
}
