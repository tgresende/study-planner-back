using Domain.Entities;
using Domain.ReponseModels.Topic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITopicRepository
    {
        Task<List<GetTopicsFromSubjectResponseModel>> GetTopicsFromSubject(Subject subject);

        Task<List<int>> GetTopicsIds(Subject subject);

        Task<Topic> GetTopic(int topicId);

        Task<Topic> GetTopic(string topicName, Subject subject);

        Task InsertTopic(Topic topic);
    }
}