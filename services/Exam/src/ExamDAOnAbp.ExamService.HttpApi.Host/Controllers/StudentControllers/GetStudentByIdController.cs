using ExamDAOnAbp.ExamService.DTOs;
using ExamDAOnAbp.ExamService.Interfaces.StudentAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamDAOnAbp.ExamService.Controllers.StudentControllers
{
    [Route("api/student/id")]
    [ApiController]
    public class GetStudentByIdController : ControllerBase
    {
        private readonly IGetStudentByIdAppService _getStudentByIdAppService;

        public GetStudentByIdController(IGetStudentByIdAppService getStudentByIdAppService)
        {
            _getStudentByIdAppService = getStudentByIdAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetAsync(Guid id)
        {
            var result = await _getStudentByIdAppService.GetAsync(id);
            return Ok(result);
        }
    }
}
