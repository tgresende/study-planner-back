using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations.DatabaseConfigurations
{
    public class DatabaseSubjectTaskConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<SubjectTask>()
               .HasOne(e => e.Subject)
               .WithMany(e => e.SubjectTasks)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}