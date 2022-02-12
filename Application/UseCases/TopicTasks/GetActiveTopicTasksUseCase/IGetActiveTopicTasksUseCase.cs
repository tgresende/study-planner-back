using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.GetActiveTopicTasksUseCase
{
    public interface IGetActiveTopicTasksUseCase
    {
        Task<List<GetActiveTopicTaskResponseModel>?> GetActiveTopicTasks(int subjectId);
    }
}