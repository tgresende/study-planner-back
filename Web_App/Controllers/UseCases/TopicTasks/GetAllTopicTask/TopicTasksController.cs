using Application.UseCases.TopicTasks.GetAllTopicTaskUseCase;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.TopicTasks.GetActiveTopicTasks
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicTasksController : ControllerBase
    {
        private readonly IGetAllTopicTaskUseCase getAllTopicTaskUseCase;

        public TopicTasksController(
            IGetAllTopicTaskUseCase getAllTopicTaskUseCase
        )
        {
            this.getAllTopicTaskUseCase = getAllTopicTaskUseCase;
        }

        [HttpGet("GetAllTopicTask/{topicId}")]
        public async Task<ActionResult> AddTopicTask(int topicId)
        {
            List<GetAllTopicTaskResponseModel> tasks =
                await getAllTopicTaskUseCase.GetAllTopicTasks(topicId);

            return Ok(tasks);
        }
    }
}