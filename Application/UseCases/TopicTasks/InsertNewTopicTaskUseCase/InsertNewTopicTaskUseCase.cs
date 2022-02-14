using Application.Services.Notifications;
using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase
{
    public class InsertNewTopicTaskUseCase : IInsertNewTopicTaskUseCase
    {
        private readonly ITopicTaskRepository topicTaskRepository;
        private readonly ITopicRepository topicRepository;
        private readonly IUnitWork unitWork;
        private readonly INotification notification;

        public InsertNewTopicTaskUseCase(
            ITopicTaskRepository topicTaskRepo,
            ITopicRepository topicRepo,
            IUnitWork unitWork,
            INotification notification
            )
        {
            this.unitWork = unitWork;
            topicTaskRepository = topicTaskRepo;
            topicRepository = topicRepo;
            this.notification = notification;
        }

        public async Task<AddTopicTaskResponseModel?> InsertNewTopicTask(InsertNewTopicTaskRequestModel topicTaskRequestModel)
        {
            ValidateTopicTaskRequestModel(topicTaskRequestModel);

            if (ErrorOccured())
                return null;

            Topic topic = await topicRepository.GetTopic(topicTaskRequestModel.TopicId);
            ValidateTopic(topic);

            if (ErrorOccured())
                return null;

            TopicTask newTopicTask = ConvertRequestModelToEntity(topicTaskRequestModel, topic);

            await topicTaskRepository.InsertNewTopicTask(newTopicTask);

            await unitWork.SaveChanges();

            return mapTopicTasktoAddTopicTaskResponseModel(newTopicTask);
        }

        private void ValidateTopic(Topic topic)
        {
            if (topic == null)
                notification.AddErrorMessage("Assunto não encontrado na base de dados");
        }

        private void ValidateTopicTaskRequestModel(InsertNewTopicTaskRequestModel topicTaskRequestModel)
        {
            if (topicTaskRequestModel.TopicId <= 0)
                notification.AddErrorMessage("Assunto não informado");
        }

        private bool ErrorOccured()
        {
            return notification.ErrorsOccured();
        }

        private TopicTask ConvertRequestModelToEntity(InsertNewTopicTaskRequestModel topicTaskRequestModel, Topic topic)
        {
            return new TopicTask
            {
                Topic = topic,
                DateTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                Action = topicTaskRequestModel.Action,
                ActionDescription = topicTaskRequestModel.ActionDescription,
                ActionSource = topicTaskRequestModel.ActionSource,
                Status = Domain.Enums.TopicTaskEnum.TopicTaskStatus.Ready
            };
        }

        private AddTopicTaskResponseModel mapTopicTasktoAddTopicTaskResponseModel(TopicTask newTopicTask)
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