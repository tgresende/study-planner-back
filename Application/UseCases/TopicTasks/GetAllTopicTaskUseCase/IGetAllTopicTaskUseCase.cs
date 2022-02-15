using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.GetAllTopicTaskUseCase
{
    public interface IGetAllTopicTaskUseCase
    {
        Task<List<GetAllTopicTaskResponseModel>> GetAllTopicTasks(int topicId);
    }
}