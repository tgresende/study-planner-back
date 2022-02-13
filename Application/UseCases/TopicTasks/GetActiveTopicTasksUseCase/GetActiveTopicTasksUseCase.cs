using Application.Services.Notifications;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.GetActiveTopicTasksUseCase
{
    public class GetActiveTopicTasksUseCase : IGetActiveTopicTasksUseCase
    {
        private readonly ITopicTaskRepository topicTaskRepository;
        private readonly INotification notification;
        private readonly ISubjectRepository subjectRepository;
        private readonly ITopicRepository topicRepository;

        public GetActiveTopicTasksUseCase(
            ITopicTaskRepository topicTaskRepository,
            INotification notification,
            ISubjectRepository subjectRepository,
            ITopicRepository topicRepository
        )
        {
            this.topicTaskRepository = topicTaskRepository;
            this.notification = notification;
            this.subjectRepository = subjectRepository;
            this.topicRepository = topicRepository;
        }

        public async Task<List<GetActiveTopicTaskResponseModel>?> GetActiveTopicTasks(int subjectId)
        {
            Subject subject = await subjectRepository.GetSubject(subjectId);

            if (subject == null)
            {
                notification.AddErrorMessage("Assunto não encontrado");
                return null;
            }

            var topicsId = await topicRepository.GetTopicsIds(subject);

            var task = await topicTaskRepository.GetActiveTopicTasks(topicsId);

            List<GetActiveTopicTaskResponseModel> respondeModelList =
                new List<GetActiveTopicTaskResponseModel>();

            foreach (TopicTask topicTask in task)
            {
                respondeModelList.Add(ConvertTopicTaskToGetActiveTopicTaskResponseModel(topicTask));
            };

            return respondeModelList;
        }

        private GetActiveTopicTaskResponseModel ConvertTopicTaskToGetActiveTopicTaskResponseModel(TopicTask task)
        {
            return new GetActiveTopicTaskResponseModel
            {
                Action = task.Action,
                ActionDescription = task.ActionDescription,
                ActionSource = task.ActionSource,
                Status = (int)task.Status,
                TopicId = task.Topic.TopicId,
                TopicTaskId = task.TopicTaskId
            };
        }
    }
}