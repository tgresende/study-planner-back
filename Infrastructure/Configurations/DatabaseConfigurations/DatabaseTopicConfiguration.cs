using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations.DatabaseConfigurations
{
    public class DatabaseTopicConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Topic>()
               .HasOne(e => e.Subject)
               .WithMany(e => e.Topics)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}