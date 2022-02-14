using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.UpdateTopicTaskUseCase
{
    public interface IUpdateTopicTaskUseCase
    {
        Task UpdateTopicTask(UpdateTopicTaskUseCaseRequestModel requestModel);
    }
}