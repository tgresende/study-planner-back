using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configurations.DependencyInjection
{
    public class RepositoriesDependencyContainer
    {
        public static void RegisterInfrasctructureRepositories(IServiceCollection services)
        {
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ITopicTaskRepository, TopicTaskRepository>();
        }
    }
}