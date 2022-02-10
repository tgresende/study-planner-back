using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations.DatabaseConfigurations
{
    public class DatabaseProjectConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder
              .Entity<Project>()
              .HasMany(e => e.Subjects)
              .WithOne(e => e.Project);
        }
    }
}