using Application.UseCases.TopicTasks.FinalizeTopicTaskUseCase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.TopicTasks.FinalizeTopicTask
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicTasksController : ControllerBase
    {
        private readonly IFinalizeTopicTaskUseCase finalizeTopicTask;

        public TopicTasksController(
           IFinalizeTopicTaskUseCase finalizeTopicTask
        )
        {
            this.finalizeTopicTask = finalizeTopicTask;
        }

        [HttpPost("FinalizeTopicTask")]
        public async Task<ActionResult> FinalizeTopicTask([FromBody] FinalizeTopicTaskUseCaseRequestModel requestModel)
        {
            await finalizeTopicTask.FinalizeTopicTask(requestModel);
            return Ok();
        }
    }
}