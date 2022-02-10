using Application.UseCases.Subjects.GetSubjectsFromProjectUseCase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.Subjects
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly IGetSubjectsFromProjectUseCase _getSubjectsUseCase;

        public SubjectsController(IGetSubjectsFromProjectUseCase getSubjectsUseCase)
        {
            this._getSubjectsUseCase = getSubjectsUseCase;
        }

        [HttpGet("GetSubjectsFromProject/{projectId}")]
        public async Task<IActionResult> Get(int projectId)
        {
            var data = await _getSubjectsUseCase.GetSubjectsFromProject(projectId);

            return Ok(data);
        }
    }
}