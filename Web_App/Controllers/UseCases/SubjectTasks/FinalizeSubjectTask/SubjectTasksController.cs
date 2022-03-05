using Application.UseCases.SubjectTasks.FinalizeSubjectTaskUseCase;
using Application.UseCases.TopicTasks.FinalizeTopicTaskUseCase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.SubjectTasks.FinalizeSubjectTask
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectTasksController : ControllerBase
    {
        private readonly IFinalizeSubjectTaskUseCase _finalizeSubjectTaskUseCase;

        public SubjectTasksController(
           IFinalizeSubjectTaskUseCase finalizeSubjectTask
        )
        {
            _finalizeSubjectTaskUseCase = finalizeSubjectTask;
        }

        [HttpDelete("FinalizeSubjectTask/{subjectTaskId}")]
        public async Task<ActionResult> FinalizeSubjectTask(int subjectTaskId)
        {
            await _finalizeSubjectTaskUseCase.FinalizeSubjectTask(subjectTaskId);
            return Ok();
        }
    }
}