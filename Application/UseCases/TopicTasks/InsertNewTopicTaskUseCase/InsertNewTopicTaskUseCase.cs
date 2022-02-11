﻿using Application.Services.Notifications;
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
            ValidateTopicTaskRequestModel(topicTaskRequestModel);

            if (ErrorOccured()) return notification;

            Topic topic = await topicRepository.GetTopic(topicTaskRequestModel.TopicId);
            ValidateTopic(topic);

            if (ErrorOccured()) return notification;

            TopicTask newTopicTask = ConvertRequestModelToEntity(topicTaskRequestModel, topic);

            await topicTaskRepository.InsertNewTopicTask(newTopicTask);

            await unitWork.SaveChanges();

            return notification;
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

            int questionsDone = topicTaskRequestModel.DoneQuestionQuantity;
            int questionsCorrect = topicTaskRequestModel.CorrectQuestionQuantity;

            if (questionsDone < questionsCorrect)
                notification.AddErrorMessage("Quantidade de questões feitas menor que a quantidade de questões corretas.");
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