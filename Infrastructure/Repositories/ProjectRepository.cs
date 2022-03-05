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
    public class ProjectRepository : IProjectRepository
    {
        private AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Project> GetProject(int projectId)
        {
            return await _context.Projects.FindAsync(projectId);
        }

        public async Task<Project> GetSubjectsProject(int projectId)
        {
            return await _context.Projects
                .Include(proj => proj.Subjects)
                .ThenInclude(sub => sub.Topics)
                .ThenInclude(top => top.TopicTasks)
                .Where(proj => proj.ProjectId == projectId)
                .FirstOrDefaultAsync();
        }
    }
}