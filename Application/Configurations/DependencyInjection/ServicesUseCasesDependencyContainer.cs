using Application.Services.Notifications;
using Application.UseCases.Subjects.GetSubjectsFromProjectUseCase;
using Application.UseCases.Topics.AddTopicUseCase;
using Application.UseCases.Topics.GetTopicsFromSubjectUseCase;
using Application.UseCases.TopicTasks.GetActiveTopicTasksUseCase;
using Application.UseCases.TopicTasks.InsertNewTopicTaskUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations.DependencyInjection
{
    public class ServicesUseCasesDependencyContainer
    {
        public static void RegisterApplcationUseCases(IServiceCollection services)
        {
            services.AddScoped<IGetSubjectsFromProjectUseCase, GetSubjectsFromProjectUseCase>();

            services.AddScoped<IGetTopicsFromSubjectUseCase, GetTopicsFromSubjectUseCase>();
            services.AddScoped<IAddTopicUseCase, AddTopicUseCase>();

            services.AddScoped<IInsertNewTopicTaskUseCase, InsertNewTopicTaskUseCase>();
            services.AddScoped<IGetActiveTopicTasksUseCase, GetActiveTopicTasksUseCase>();
        }

        public static void RegisterApplcationServices(IServiceCollection services)
        {
            services.AddScoped<INotification, Notification>();
        }
    }
}