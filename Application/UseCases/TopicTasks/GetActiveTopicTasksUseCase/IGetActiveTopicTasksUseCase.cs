using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.GetActiveTopicTasksUseCase
{
    public interface IGetActiveTopicTasksUseCase
    {
        Task<List<GetActiveTopicTaskResponseModel>?> GetActiveTopicTasks(int subjectId);
    }
}