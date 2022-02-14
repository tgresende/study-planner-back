using Domain.Entities;
using Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.FinalizeTopicTaskUseCase
{
    public class FinalizeTopicTaskUseCase : IFinalizeTopicTaskUseCase
    {
        private readonly ITopicTaskRepository topicTaskRepository;
        private readonly IUnitWork unitWork;

        public FinalizeTopicTaskUseCase(ITopicTaskRepository topicTaskRepository,
            IUnitWork unitWork)
        {
            this.topicTaskRepository = topicTaskRepository;
            this.unitWork = unitWork;
        }

        public async Task FinalizeTopicTask(FinalizeTopicTaskUseCaseRequestModel requestModel)
        {
            TopicTask topicTask = await topicTaskRepository.GetTopicTask(requestModel.TopicTaskId);

            if (topicTask == null)
                return;

            topicTask.ActionSource = requestModel.ActionSource;
            topicTask.ActionDescription = requestModel.ActionDescription;
            topicTask.RevisionItem = requestModel.RevisionItem;
            topicTask.DoneQuestionQuantity = requestModel.DoneQuestionQuantity;
            topicTask.CorrectQuestionQuantity = requestModel.CorrectQuestionQuantity;
            topicTask.Status = Domain.Enums.TopicTaskEnum.TopicTaskStatus.Finished;

            await unitWork.SaveChanges();
        }
    }
}