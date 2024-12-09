using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.ExamPaperAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.ExamService.Controllers.ExamPaperControllers
{
    [Route("api/exam-papers")]
    [ApiController]
    public class GetListExamPapersController : ControllerBase
    {
        private readonly IGetListExamPapersAppService _getListExamPapersAppService;

        public GetListExamPapersController(IGetListExamPapersAppService getListExamPapersAppService)
        {
            _getListExamPapersAppService = getListExamPapersAppService;
        }

        [HttpGet]
        public async Task<ActionResult<ListResultDto<ExamPaperDto>>> GetListAsync()
        {
            var result = await _getListExamPapersAppService.GetListAsync();
            return Ok(result);
        }
    }
}
