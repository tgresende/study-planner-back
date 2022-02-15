using Domain.Entities;
using Domain.ReponseModels.Topic;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            List<int> topicIds = new List<int> { 2014, 2013 };

            return await _context.TopicTasks
                        .Where(task => task.Topic.Subject == subject)
                        .GroupBy(r => new { r.Topic.TopicId, r.Topic.Anotations, r.Topic.Name })
                        .Select(m => new GetTopicsFromSubjectResponseModel
                        {
                            TopicId = m.Key.TopicId,
                            TopicAnotations = m.Key.Anotations,
                            TopicName = m.Key.Name,
                            TotalCorrectQuestion = m.Sum(r => r.CorrectQuestionQuantity),
                            TotalDoneQuestion = m.Sum(r => r.DoneQuestionQuantity)
                        }
                     ).ToListAsync();
        }

        public async Task<List<int>> GetTopicsIds(Subject subject)
        {
            return await _context.Topics
              .Where(topic => topic.Subject == subject)
              .Select(topic => topic.TopicId)
              .ToListAsync();
        }

        public async Task InsertTopic(Topic topic)
        {
            await _context.Topics.AddAsync(topic);
        }

        public async Task<Topic> GetTopic(int topicId)
        {
            return await _context.Topics.FindAsync(topicId);
        }

        public async Task<Topic> GetTopic(string topicName, Subject subject)
        {
            return await _context.Topics.FirstOrDefaultAsync(
                topic => topic.Name == topicName && topic.Subject == subject
            );
        }
    }
}