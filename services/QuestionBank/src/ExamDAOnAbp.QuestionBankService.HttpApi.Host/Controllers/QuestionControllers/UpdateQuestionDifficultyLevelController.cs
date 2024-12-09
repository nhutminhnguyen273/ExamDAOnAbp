using ExamDAOnAbp.QuestionBankService.DTOs;
using ExamDAOnAbp.QuestionBankService.Interfaces.QuestionAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamDAOnAbp.QuestionBankService.Controllers.QuestionControllers
{
    [Route("api/update-difficulty")]
    [ApiController]
    public class UpdateQuestionDifficultyLevelController : ControllerBase
    {
        private readonly IUpdateQuestionDifficulty _updateQuestionDifficulty;

        public UpdateQuestionDifficultyLevelController(IUpdateQuestionDifficulty updateQuestionDifficulty)
        {
            _updateQuestionDifficulty = updateQuestionDifficulty;
        }

        [HttpPut]
        public async Task<ActionResult<QuestionDto>> UpdateAsync()
        {
            var result = await _updateQuestionDifficulty.UpdateAsync();
            return Ok(result);
        }
    }
}
