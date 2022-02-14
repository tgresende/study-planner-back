using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.FinalizeTopicTaskUseCase
{
    public interface IFinalizeTopicTaskUseCase
    {
        Task FinalizeTopicTask(FinalizeTopicTaskUseCaseRequestModel requestModel);
    }
}