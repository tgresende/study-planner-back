using Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase;
using Domain.Entities;

namespace Application.Services.TopicTasks
{
    public interface ITopicTaskServices
    {
        Domain.Entities.TopicTask ConvertRequestModelToEntity(InsertNewTopicTaskRequestModel topicTaskRequestModel, Topic topic);

        Domain.Entities.TopicTask ConvertToEntity(Topic topic, string action);

        AddTopicTaskResponseModel MapTopicTasktoAddTopicTaskResponseModel(Domain.Entities.TopicTask newTopicTask);
    }
}