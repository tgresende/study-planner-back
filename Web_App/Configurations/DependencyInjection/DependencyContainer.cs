using Application.UseCases.Subjects.GetSubjectsFromProjectUseCase;
using Application.Configurations.DependencyInjection;
using Infrastructure.Configurations.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

namespace Web_App.Configurations.DependencyInjection
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            ServicesUseCasesDependencyContainer.RegisterApplcationServices(services);
            ServicesUseCasesDependencyContainer.RegisterApplcationUseCases(services);
            RepositoriesDependencyContainer.RegisterInfrasctructureRepositories(services);
        }
    }
}