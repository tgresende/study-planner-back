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
    public class TopicTaskRepository : ITopicTaskRepository
    {
        private AppDbContext context;

        public TopicTaskRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task InsertNewTopicTask(TopicTask topicTask)
        {
            await context.TopicTasks.AddAsync(topicTask);
        }

        public async Task<List<TopicTask>> GetActiveTopicTasks(Subject subject)
        {
            Subject sub = await context.Subjects
                .Include(sub => sub.Topics)
                .ThenInclude(top => top.TopicTasks)
                .FirstOrDefault(sub => sub.SubjectId == subject.SubjectId);
        }
    }
}