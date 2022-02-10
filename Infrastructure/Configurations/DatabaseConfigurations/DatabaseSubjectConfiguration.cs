using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations.DatabaseConfigurations
{
    public class DatabaseSubjectConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Subject>()
                .HasOne(e => e.Project)
                .WithMany(e => e.Subjects)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
              .Entity<Subject>()
              .HasMany(e => e.Topics)
              .WithOne(e => e.Subject);
        }
    }
}