using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ISubjectTaskRepository
    {
        Task InsertSubjectTasks(List<SubjectTask> subjectTasks);

        Task<List<SubjectTask>> GetActiveSubjectTasks(int projectId);

        Task<SubjectTask> GetSubjectTask(int subjectTaskId);
    }
}