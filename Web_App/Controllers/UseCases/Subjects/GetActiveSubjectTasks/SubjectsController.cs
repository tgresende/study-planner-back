using Application.UseCases.Subjects.GetActiveSubjectTasksUseCase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.Subjects.GetActiveSubjectTasks
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly IGetActiveSubjectTasksUseCase getActiveSubjectTasksUseCase;

        public SubjectsController(IGetActiveSubjectTasksUseCase getActiveSubjectTasksUseCase)
        {
            this.getActiveSubjectTasksUseCase = getActiveSubjectTasksUseCase;
        }

        [HttpGet("GetActiveSubjectTasks/{projectId}")]
        public async Task<IActionResult> Get(int projectId)
        {
            var data = await getActiveSubjectTasksUseCase.GetActiveSubjectTasks(projectId);

            return Ok(data);
        }
    }
}