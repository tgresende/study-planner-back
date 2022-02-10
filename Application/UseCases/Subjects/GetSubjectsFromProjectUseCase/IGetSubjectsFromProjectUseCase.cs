using Domain.ReponseModels.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Subjects.GetSubjectsFromProjectUseCase
{
    public interface IGetSubjectsFromProjectUseCase
    {
        public Task<List<GetSubjectsFromProjectResponseModel>> GetSubjectsFromProject(int projectId);
    }
}