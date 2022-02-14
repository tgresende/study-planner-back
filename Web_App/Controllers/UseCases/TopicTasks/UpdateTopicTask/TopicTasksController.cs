using Application.UseCases.TopicTasks.UpdateTopicTaskUseCase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.TopicTasks.UpdateTopicTask
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicTasksController : ControllerBase
    {
        private readonly IUpdateTopicTaskUseCase updateTopicTask;

        public TopicTasksController(
            IUpdateTopicTaskUseCase updateTopicTask
        )
        {
            this.updateTopicTask = updateTopicTask;
        }

        [HttpPost("UpdateTopicTask")]
        public async Task<ActionResult> UpdateTopicTask([FromBody] UpdateTopicTaskUseCaseRequestModel requestModel)
        {
            await updateTopicTask.UpdateTopicTask(requestModel);
            return Ok();
        }
    }
}