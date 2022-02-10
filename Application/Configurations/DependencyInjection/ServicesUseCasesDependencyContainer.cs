using Application.Services.Notifications;
using Application.UseCases.Subjects.GetSubjectsFromProjectUseCase;
using Application.UseCases.Topics.GetTopicsFromSubjectUseCase;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configurations.DependencyInjection
{
    public class ServicesUseCasesDependencyContainer
    {
        public static void RegisterApplcationUseCases(IServiceCollection services)
        {
            services.AddScoped<IGetSubjectsFromProjectUseCase, GetSubjectsFromProjectUseCase>();
            services.AddScoped<IGetTopicsFromSubjectUseCase, GetTopicsFromSubjectUseCase>();
        }

        public static void RegisterApplcationServices(IServiceCollection services)
        {
            services.AddScoped<INotification, Notification>();
        }
    }
}