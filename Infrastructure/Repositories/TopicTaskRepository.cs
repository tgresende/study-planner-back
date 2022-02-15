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

        public async Task<List<TopicTask>> GetActiveTopicTasks(List<int> topicIds)
        {
            return await context.TopicTasks
                .Where(task =>
                    task.Status == Domain.Enums.TopicTaskEnum.TopicTaskStatus.Ready &&
                    topicIds.Any(id => id == task.Topic.TopicId)
                 )
                .Include(task => task.Topic)
                .ToListAsync();
        }

        public async Task<TopicTask> GetTopicTask(int topicTaskId)
        {
            return await context.TopicTasks
                .FindAsync(topicTaskId);
        }

        public async Task<TopicTask> GetLastTopicTask(Topic topic)
        {
            return await context.TopicTasks
                .OrderByDescending(x => x.DateTimestamp)
                .FirstOrDefaultAsync(task => task.Topic == topic);
        }
    }
}