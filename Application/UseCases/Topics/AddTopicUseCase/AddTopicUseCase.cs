using Application.Services.Notifications;
using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.Topics.AddTopicUseCase
{
    public class AddTopicUseCase : IAddTopicUseCase
    {
        private readonly INotification notification;
        private readonly ISubjectRepository subjectRepository;
        private readonly ITopicRepository topicRepository;
        private readonly IUnitWork unitWork;

        public AddTopicUseCase(ISubjectRepository subjectRepository, ITopicRepository topicRepository,
            INotification notification, IUnitWork unitWork)
        {
            this.notification = notification;
            this.subjectRepository = subjectRepository;
            this.topicRepository = topicRepository;
            this.unitWork = unitWork;
        }

        public async Task<AddTopicResponseModel?> InsertTopic(AddNewTopicRequestModel requestModel)
        {
            IsValidRequestModel(requestModel);

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

            bool validTopicName = await IsValidTopicName(requestModel, subject);

            if (!validTopicName)
            {
                notification.AddErrorMessage("Tópico já existe.");
                return null;
            }

            Topic topic = new Topic
            {
                Anotations = requestModel.Anotations,
                Name = requestModel.Name,
                Subject = subject
            };

            await topicRepository.InsertTopic(topic);

            await unitWork.SaveChanges();

            return MapTopicToAddTopicResponseModel(topic);
        }

        private void IsValidRequestModel(AddNewTopicRequestModel requestModel)
        {
            if (requestModel.SubjectId == 0)
                notification.AddErrorMessage("Assunto não informado");

            if (String.IsNullOrEmpty(requestModel.Name))
                notification.AddErrorMessage("Nome do tópico não informado");
        }

        private AddTopicResponseModel MapTopicToAddTopicResponseModel(Topic topic)
        {
            return new AddTopicResponseModel
            {
                TopicId = topic.TopicId,
                Anotations = topic.Anotations,
                Name = topic.Name,
                SubjectId = topic.Subject.SubjectId
            };
        }

        private async Task<bool> IsValidTopicName(AddNewTopicRequestModel requestModel, Subject subject)
        {
            Topic topic = await topicRepository.GetTopic(requestModel.Name, subject);

            return (topic == null);
        }
    }
}