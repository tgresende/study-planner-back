using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.GetAllTopicTaskUseCase
{
    public class GetAllTopicTaskUseCase : IGetAllTopicTaskUseCase
    {
        private readonly ITopicRepository topicRepository;
        private readonly ITopicTaskRepository topicTaskRepository;

        public GetAllTopicTaskUseCase(
            ITopicRepository topicRepository,
            ITopicTaskRepository topicTaskRepository)
        {
            this.topicTaskRepository = topicTaskRepository;
            this.topicRepository = topicRepository;
        }

        public async Task<List<GetAllTopicTaskResponseModel>> GetAllTopicTasks(int topicId)
        {
            Topic topic = await topicRepository.GetTopic(topicId);
            var responseModel = new List<GetAllTopicTaskResponseModel>();

            if (topic == null)
                return responseModel;

            var tasks = await topicTaskRepository.GetAllTopicTasks(topic);

            foreach (var task in tasks)
            {
                responseModel.Add(ConvertTopicTaskToResponseModel(task));
            };

            return responseModel;
        }

        private GetAllTopicTaskResponseModel ConvertTopicTaskToResponseModel(TopicTask task)
        {
            return new GetAllTopicTaskResponseModel
            {
                Action = task.Action,
                ActionDescription = task.ActionDescription,
                ActionSource = task.ActionSource,
                CorrectQuestionQuantity = task.CorrectQuestionQuantity,
                DateTimestamp = task.DateTimestamp,
                DoneQuestionQuantity = task.DoneQuestionQuantity,
                RevisionItem = task.RevisionItem,
                Status = task.Status,
                TopicTaskId = task.TopicTaskId
            };
        }
    }
}