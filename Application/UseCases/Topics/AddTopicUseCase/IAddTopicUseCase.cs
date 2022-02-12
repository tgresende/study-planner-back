using Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Topics.AddTopicUseCase
{
    public interface IAddTopicUseCase
    {
        Task<Topic> InsertTopic(AddNewTopicRequestModel requestModel);
    }
}