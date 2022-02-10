using Domain.Entities;
using Domain.ReponseModels.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ISubjectRepository
    {
        Task<List<GetSubjectsFromProjectResponseModel>> GetSubjectsFromProject(Project project);
    }
}