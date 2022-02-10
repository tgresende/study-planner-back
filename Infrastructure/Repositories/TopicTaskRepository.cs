using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
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
    }
}