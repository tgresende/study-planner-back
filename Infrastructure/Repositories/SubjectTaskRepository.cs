using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SubjectTaskRepository : ISubjectTaskRepository
    {
        private AppDbContext context;

        public SubjectTaskRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task InsertSubjectTasks(List<SubjectTask> subjectTasks)
        {
            await context.SubjectTasks.AddRangeAsync(subjectTasks);
        }

        public async Task<List<SubjectTask>> GetActiveSubjectTasks(int projectId)
        {
            return await context.SubjectTasks
                .Where(task =>
                    task.Status == Domain.Enums.TaskEnum.TaskStatus.Ready &&
                    task.Subject.Project.ProjectId == projectId)
                .Include(task => task.Subject)
                .OrderBy(task => task.InternalOrder)
                .ToListAsync();
        }

        public async Task<SubjectTask> GetSubjectTask(int subjectTaskId)
        {
            return await context.SubjectTasks
                .FindAsync(subjectTaskId);
        }
    }
}