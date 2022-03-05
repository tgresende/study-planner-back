using Domain.ReponseModels.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Subjects.GetActiveSubjectTasksUseCase
{
    public interface IGetActiveSubjectTasksUseCase
    {
        public Task<List<GetActiveSubjectTasksResponseModel>> GetActiveSubjectTasks(int projectId);
    }
}