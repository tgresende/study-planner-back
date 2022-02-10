using Application.Services.Notifications;
using Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.TopicTasks.InsertNewTopicTask
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicTasksController : ControllerBase
    {
        private readonly IInsertNewTopicTaskUseCase insertNewTopicTaskUseCase;

        public TopicTasksController(IInsertNewTopicTaskUseCase insertNewTopicTaskUseCase)
        {
            this.insertNewTopicTaskUseCase = insertNewTopicTaskUseCase;
        }

        [HttpPost("InsertNewTopicTask")]
        public async Task<ActionResult> AddTopicTask([FromBody] InsertNewTopicTaskRequestModel requestModel)
        {
            Notification notification = await insertNewTopicTaskUseCase.InsertNewTopicTask(requestModel);

            if (notification.ErrorsOccured())
                return BadRequest(notification.GetErrorMessages());

            return Ok();
        }
    }
}