using Domain.Entities;
using Domain.ReponseModels.Topic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITopicRepository
    {
        Task<List<GetTopicsFromSubjectResponseModel>> GetTopicsFromSubject(Subject subject);

        Task<Topic> GetTopic(int topicId);
    }
}