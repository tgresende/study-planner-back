using Application.Services.Notifications;
using Application.Services.TopicTask;
using Application.Services.TopicTasks;
using Application.UseCases.Subjects.GetSubjectsFromProjectUseCase;
using Application.UseCases.Subjects.UpdateSubjectAnnotationsUseCase;
using Application.UseCases.Topics.AddTopicUseCase;
using Application.UseCases.Topics.GetTopicsFromSubjectUseCase;
using Application.UseCases.TopicTasks.FinalizeTopicTaskUseCase;
using Application.UseCases.TopicTasks.GenerataCycleTaskUseCase;
using Application.UseCases.TopicTasks.GetActiveTopicTasksUseCase;
using Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase;
using Application.UseCases.TopicTasks.UpdateTopicTaskUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations.DependencyInjection
{
    public class ServicesUseCasesDependencyContainer
    {
        public static void RegisterApplcationUseCases(IServiceCollection services)
        {
            services.AddScoped<IGetSubjectsFromProjectUseCase, GetSubjectsFromProjectUseCase>();
            services.AddScoped<IUpdateSubjectAnnotationsUseCase, UpdateSubjectAnnotationsUseCase>();

            services.AddScoped<IGetTopicsFromSubjectUseCase, GetTopicsFromSubjectUseCase>();
            services.AddScoped<IAddTopicUseCase, AddTopicUseCase>();

            services.AddScoped<IInsertNewTopicTaskUseCase, InsertNewTopicTaskUseCase>();
            services.AddScoped<IGetActiveTopicTasksUseCase, GetActiveTopicTasksUseCase>();
            services.AddScoped<IUpdateTopicTaskUseCase, UpdateTopicTaskUseCase>();
            services.AddScoped<IFinalizeTopicTaskUseCase, FinalizeTopicTaskUseCase>();
            services.AddScoped<IGenerateCycleTaskUseCase, GenerateCycleTaskUseCase>();
        }

        public static void RegisterApplcationServices(IServiceCollection services)
        {
            services.AddScoped<INotification, Notification>();
            services.AddScoped<ITopicTaskServices, TopicTaskServices>();
        }
    }
}