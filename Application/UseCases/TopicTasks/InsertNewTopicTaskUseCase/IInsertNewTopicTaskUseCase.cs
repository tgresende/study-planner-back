using Application.Services.Notifications;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase
{
    public interface IInsertNewTopicTaskUseCase
    {
        Task<Notification> InsertNewTopicTask(InsertNewTopicTaskRequestModel topicTaskRequestModel);
    }
}