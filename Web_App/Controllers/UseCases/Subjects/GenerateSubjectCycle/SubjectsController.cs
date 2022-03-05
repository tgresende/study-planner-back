using Application.UseCases.Subjects.GenerateSubjectCycleUseCase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.Subjects.GenerateSubjectCycle
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly IGenerateSubjectCycleUseCase _generateSubjectCycleUseCase;

        public SubjectsController(IGenerateSubjectCycleUseCase generateSubjectCycleUseCase)
        {
            this._generateSubjectCycleUseCase = generateSubjectCycleUseCase;
        }

        [HttpPost("GenerateSubjectCycleUseCase/{projectId}")]
        public async Task<IActionResult> Get(int projectId)
        {
            await _generateSubjectCycleUseCase.GenerateSubjectCycle(projectId);

            return Ok();
        }
    }
}