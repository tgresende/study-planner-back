using Application.Services.Notifications;
using Application.UseCases.Topics.AddTopicUseCase;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web_App.Controllers.UseCases.Topics.InsertNewTopic
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly IAddTopicUseCase addTopicUseCase;
        private readonly INotification notification;

        public TopicsController(
            IAddTopicUseCase addTopicUseCase, INotification notification)
        {
            this.addTopicUseCase = addTopicUseCase;
            this.notification = notification;
        }

        [HttpPost("InsertTopic")]
        public async Task<IActionResult> Get([FromBody] AddNewTopicRequestModel requestModel)
        {
            AddTopicResponseModel newTopic = await addTopicUseCase.InsertTopic(requestModel);

            if (notification.ErrorsOccured())
                return BadRequest(notification.GetErrorMessages());

            return Ok(newTopic);
        }
    }
}