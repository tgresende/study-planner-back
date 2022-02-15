using Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.GenerataCycleTaskUseCase
{
    public interface IGenerateCycleTaskUseCase
    {
        Task<List<AddTopicTaskResponseModel>> GenerateCycleTask(List<GenerateCycleTaskUseCaseRequestModel> topics);
    }
}