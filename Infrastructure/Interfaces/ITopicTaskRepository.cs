using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITopicTaskRepository
    {
        Task InsertNewTopicTask(TopicTask topicTask);

        Task<List<TopicTask>> GetActiveTopicTasks(List<int> topicIds);

        Task<TopicTask> GetTopicTask(int topicTaskId);

        Task<TopicTask> GetLastTopicTask(Topic topic);

        Task<List<TopicTask>> GetAllTopicTasks(Topic topic);
    }
}