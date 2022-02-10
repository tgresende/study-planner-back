using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations.DatabaseConfigurations
{
    public class DatabaseTopicTaskConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<TopicTask>()
               .HasOne(e => e.Topic)
               .WithMany(e => e.TopicTasks)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}