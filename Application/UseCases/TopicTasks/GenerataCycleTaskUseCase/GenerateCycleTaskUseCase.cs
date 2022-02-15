using Application.Services.TopicTasks;
using Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases.TopicTasks.GenerataCycleTaskUseCase
{
    public class GenerateCycleTaskUseCase : IGenerateCycleTaskUseCase
    {
        private readonly ITopicRepository topicRepository;
        private readonly ITopicTaskRepository topicTaskRepository;
        private readonly ITopicTaskServices topicTaskServices;
        private readonly IUnitWork unitWork;

        public GenerateCycleTaskUseCase(ITopicRepository topicRepository,
            ITopicTaskRepository topicTaskRepository,
            ITopicTaskServices topicTaskServices,
            IUnitWork unitWork
        )
        {
            this.topicRepository = topicRepository;
            this.topicTaskRepository = topicTaskRepository;
            this.topicTaskServices = topicTaskServices;
            this.unitWork = unitWork;
        }

        public async Task<List<AddTopicTaskResponseModel>> GenerateCycleTask(List<GenerateCycleTaskUseCaseRequestModel> topics)
        {
            var tasksReponse = new List<AddTopicTaskResponseModel>();

            foreach (GenerateCycleTaskUseCaseRequestModel topicModel in topics)
            {
                var topic = await topicRepository.GetTopic(topicModel.TopicId);
                var task = await topicTaskRepository.GetLastTopicTask(topic);
                var newTask = GetNextCycleTask(task, topicModel.Score);
                await topicTaskRepository.InsertNewTopicTask(newTask);
                tasksReponse.Add(topicTaskServices.MapTopicTasktoAddTopicTaskResponseModel(newTask));
            }

            await unitWork.SaveChanges();

            return tasksReponse;
        }

        private TopicTask GetNextCycleTask(TopicTask task, string score)
        {
            string nextAction;
            if (score == "A")
                nextAction = GetNextCycleA(task);
            else if (score == "B")
                nextAction = GetNextCycleB(task);
            else
                nextAction = GetNextCycleC(task);

            return topicTaskServices.ConvertToEntity(task.Topic, nextAction);
        }

        private string GetNextCycleA(TopicTask lastTask)
        {
            switch (lastTask.Action)
            {
                case "Questões 1":
                    return "Questões 2";

                case "Questões 2":
                    return "Questões de Revisão";

                case "Questões de Revisão":
                    return "Lei Seca";

                default:
                    return "Questões 1";
            }
        }

        private string GetNextCycleB(TopicTask lastTask)
        {
            switch (lastTask.Action)
            {
                case "Questões 1":
                    return "Questões de Revisão";

                case "Questões de Revisão":
                    return "Questões 2";

                case "Questões 2":
                    return "Leitura";

                default:
                    return "Questões 1";
            }
        }

        private string GetNextCycleC(TopicTask lastTask)
        {
            switch (lastTask.Action)
            {
                case "Leitura":
                    return "Questões 1";

                case "Questões 1":
                    return "Questões de Revisão";

                default:
                    return "Leitura";
            }
        }
    }
}