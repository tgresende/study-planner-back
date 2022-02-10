using Domain.Entities;
using Domain.ReponseModels.Topic;
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
    public class TopicRepository : ITopicRepository
    {
        private AppDbContext _context;

        public TopicRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetTopicsFromSubjectResponseModel>> GetTopicsFromSubject(Subject subject)
        {
            return await _context.Topics
                .Where(topic => topic.Subject == subject)
               .Select(topic => new GetTopicsFromSubjectResponseModel
               {
                   TopicId = topic.TopicId,
                   Name = topic.Name
               }).ToListAsync();
        }
    }
}