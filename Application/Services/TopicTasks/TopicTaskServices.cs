using Application.Services.TopicTasks;
using Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase;
using Domain.Entities;
using System;

namespace Application.Services.TopicTask
{
    public class TopicTaskServices : ITopicTaskServices
    {
        public Domain.Entities.TopicTask ConvertRequestModelToEntity(InsertNewTopicTaskRequestModel topicTaskRequestModel, Topic topic)
        {
            return new Domain.Entities.TopicTask
            {
                Topic = topic,
                DateTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                Action = topicTaskRequestModel.Action,
                ActionDescription = topicTaskRequestModel.ActionDescription,
                ActionSource = topicTaskRequestModel.ActionSource,
                Status = Domain.Enums.TopicTaskEnum.TopicTaskStatus.Ready
            };
        }

        public Domain.Entities.TopicTask ConvertToEntity(Topic topic, string action)
        {
            return new Domain.Entities.TopicTask
            {
                Topic = topic,
                DateTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                Action = action,
                Status = Domain.Enums.TopicTaskEnum.TopicTaskStatus.Ready
            };
        }

        public AddTopicTaskResponseModel MapTopicTasktoAddTopicTaskResponseModel(Domain.Entities.TopicTask newTopicTask)
        {
            return new AddTopicTaskResponseModel
            {
                TopicId = newTopicTask.Topic.TopicId,
                TopicTaskId = newTopicTask.TopicTaskId,
                Action = newTopicTask.Action,
                ActionDescription = newTopicTask.ActionDescription,
                ActionSource = newTopicTask.ActionSource,
                Status = (int)newTopicTask.Status,
                TopicName = newTopicTask.Topic.Name
            };
        }
    }
}