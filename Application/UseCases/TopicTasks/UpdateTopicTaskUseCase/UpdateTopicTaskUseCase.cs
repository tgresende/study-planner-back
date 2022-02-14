using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.UpdateTopicTaskUseCase
{
    public class UpdateTopicTaskUseCase : IUpdateTopicTaskUseCase
    {
        private readonly ITopicTaskRepository topicTaskRepository;
        private readonly IUnitWork unitWork;

        public UpdateTopicTaskUseCase(ITopicTaskRepository topicTaskRepository,
            IUnitWork unitWork)
        {
            this.topicTaskRepository = topicTaskRepository;
            this.unitWork = unitWork;
        }

        public async Task UpdateTopicTask(UpdateTopicTaskUseCaseRequestModel requestModel)
        {
            TopicTask topicTask = await topicTaskRepository.GetTopicTask(requestModel.TopicTaskId);

            if (topicTask == null)
                return;

            topicTask.ActionSource = requestModel.ActionSource;
            topicTask.ActionDescription = requestModel.ActionDescription;

            await unitWork.SaveChanges();
        }
    }
}