using ExamDAOnAbp.LearningOutcomeService.DTOs;
using ExamDAOnAbp.LearningOutcomeService.Interfaces.DepartmentAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ExamDAOnAbp.LearningOutcomeService.Controllers.DepartmentControllers
{
    [Route("api/departments/list")]
    [ApiController]
    public class GetListDepartmentsController : ControllerBase
    {
        private readonly IGetListDepartmentsAppService _getListDepartmentAppService;

        public GetListDepartmentsController(IGetListDepartmentsAppService getListDepartmentAppService)
        {
            _getListDepartmentAppService = getListDepartmentAppService;
        }

        [HttpGet]
        public async Task<ActionResult<ListResultDto<DepartmentDto>>> GetListAsync()
        {
            var result = await _getListDepartmentAppService.GetListAsync();
            return Ok(result);
        }
    }
}
