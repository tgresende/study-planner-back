using Application.Services.Notifications;
using Application.Services.TopicTasks;
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
        private readonly ITopicTaskServices topicTaskServices;

        public InsertNewTopicTaskUseCase(
            ITopicTaskRepository topicTaskRepo,
            ITopicRepository topicRepo,
            IUnitWork unitWork,
            INotification notification,
            ITopicTaskServices topicTaskServices
            )
        {
            this.unitWork = unitWork;
            topicTaskRepository = topicTaskRepo;
            topicRepository = topicRepo;
            this.notification = notification;
            this.topicTaskServices = topicTaskServices;
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

            TopicTask newTopicTask = topicTaskServices.ConvertRequestModelToEntity(topicTaskRequestModel, topic);

            await topicTaskRepository.InsertNewTopicTask(newTopicTask);

            await unitWork.SaveChanges();

            return topicTaskServices.MapTopicTasktoAddTopicTaskResponseModel(newTopicTask);
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
    }
}