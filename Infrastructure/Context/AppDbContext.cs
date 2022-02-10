using Domain.Entities;
using Infrastructure.Configurations.DatabaseConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DatabaseProjectConfiguration.Configure(modelBuilder);
            DatabaseSubjectConfiguration.Configure(modelBuilder);
            DatabaseTopicConfiguration.Configure(modelBuilder);
        }
    }
}