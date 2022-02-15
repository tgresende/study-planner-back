using Application.UseCases.TopicTasks.FinalizeTopicTaskUseCase;
using Application.UseCases.TopicTasks.GenerataCycleTaskUseCase;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.TopicTasks.GenerateCycleTask
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicTasksController : ControllerBase
    {
        private readonly IGenerateCycleTaskUseCase generateCycleTask;

        public TopicTasksController(
           IGenerateCycleTaskUseCase generateCycleTask
        )
        {
            this.generateCycleTask = generateCycleTask;
        }

        [HttpPost("GenerateCycleTask")]
        public async Task<ActionResult> GenerateTopicTask([FromBody] List<GenerateCycleTaskUseCaseRequestModel> requestModel)
        {
            var result = await generateCycleTask.GenerateCycleTask(requestModel);
            return Ok(result);
        }
    }
}