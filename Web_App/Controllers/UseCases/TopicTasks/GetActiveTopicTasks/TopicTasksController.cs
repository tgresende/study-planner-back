using Application.Services.Notifications;
using Application.UseCases.TopicTasks.GetActiveTopicTasksUseCase;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.TopicTasks.GetAllTopicTask
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicTasksController : ControllerBase
    {
        private readonly IGetActiveTopicTasksUseCase getActiveTopicTasksUseCase;
        private readonly INotification notification;

        public TopicTasksController(
            IGetActiveTopicTasksUseCase getActiveTopicTasksUseCase,
            INotification notification
        )
        {
            this.getActiveTopicTasksUseCase = getActiveTopicTasksUseCase;
            this.notification = notification;
        }

        [HttpGet("GetActiveTopicTasks/{subjectId}")]
        public async Task<ActionResult> AddTopicTask(int subjectId)
        {
            List<GetActiveTopicTaskResponseModel> tasks =
                await getActiveTopicTasksUseCase.GetActiveTopicTasks(subjectId);

            if (notification.ErrorsOccured())
                return BadRequest(notification.GetErrorMessages());

            return Ok(tasks);
        }
    }
}