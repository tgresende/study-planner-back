using Application.Services.Notifications;
using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase
{
    public class InsertNewTopicTaskUseCase : IInsertNewTopicTaskUseCase
    {
        private readonly ITopicTaskRepository topicTaskRepository;
        private readonly ITopicRepository topicRepository;
        private readonly IUnitWork unitWork;
        private Notification notification;

        public InsertNewTopicTaskUseCase(ITopicTaskRepository topicTaskRepo,
            ITopicRepository topicRepo,
            IUnitWork unitWork)
        {
            this.unitWork = unitWork;
            topicTaskRepository = topicTaskRepo;
            topicRepository = topicRepo;
            this.notification = new Notification();
        }

        public async Task<Notification> InsertNewTopicTask(InsertNewTopicTaskRequestModel topicTaskRequestModel)
        {
            Topic topic = await topicRepository.GetTopic(topicTaskRequestModel.TopicId);

            ValidateTopic(topic);

            if (ErrorOccured()) return notification;

            TopicTask newTopicTask = ConvertRequestModelToEntity(topicTaskRequestModel, topic);

            await topicTaskRepository.InsertNewTopicTask(newTopicTask);

            return notification;
        }

        private void ValidateTopic(Topic topic)
        {
            if (topic == null)
                notification.AddErrorMessage("Assunto não encontrado na base de dados");
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
                CorrectQuestionQuantity = topicTaskRequestModel.CorrectQuestionQuantity,
                DoneQuestionQuantity = topicTaskRequestModel.DoneQuestionQuantity,
                RevisionItem = topicTaskRequestModel.RevisionItem
            };
        }
    }
}