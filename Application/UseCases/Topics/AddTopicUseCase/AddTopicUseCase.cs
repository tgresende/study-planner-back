using Application.Services.Notifications;
using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Topics.AddTopicUseCase
{
    public class AddTopicUseCase : IAddTopicUseCase
    {
        private readonly INotification notification;
        private readonly ISubjectRepository subjectRepository;
        private readonly ITopicRepository topicRepository;

        public AddTopicUseCase(ISubjectRepository subjectRepository, ITopicRepository topicRepository,
            INotification notification)
        {
            this.notification = notification;
            this.subjectRepository = subjectRepository;
            this.topicRepository = topicRepository;
        }

        public async Task<Topic?> InsertTopic(AddNewTopicRequestModel requestModel)
        {
            ValidateRequestModel(requestModel);

            if (notification.ErrorsOccured())
            {
                return null;
            }

            Subject subject = await subjectRepository.GetSubject(requestModel.SubjectId);

            if (subject == null)
            {
                notification.AddErrorMessage("Assunto não encontrado");
                return null;
            }

            Topic topic = new Topic
            {
                Anotations = requestModel.Anotations,
                Name = requestModel.Name,
                Subject = subject
            };

            await topicRepository.InsertTopic(topic);

            return topic;
        }

        private void ValidateRequestModel(AddNewTopicRequestModel requestModel)
        {
            if (requestModel.SubjectId == 0)
                notification.AddErrorMessage("Assunto não informado");

            if (String.IsNullOrEmpty(requestModel.Name))
                notification.AddErrorMessage("Nome do tópico não informado");
        }
    }
}