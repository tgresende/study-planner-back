using Domain.Entities;
using Domain.ReponseModels.Subject;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetSubjectsFromProjectResponseModel>> GetSubjectsFromProject(Project project)
        {
            return await _context.Subjects
                .Where(sub => sub.Project == project)
                .Include(sub => sub.Topics)
                .ThenInclude(top => top.TopicTasks)
                .Select(sub => new GetSubjectsFromProjectResponseModel
                {
                    SubjectId = sub.SubjectId,
                    Name = sub.Name,
                    Weight = sub.Weight,
                    Annotations = sub.Annotations,
                    Score = sub.GetScore()
                }).ToListAsync();
        }

        public async Task<Subject> GetSubject(int subjectId)
        {
            return await _context.Subjects.FindAsync(subjectId);
        }
    }
}