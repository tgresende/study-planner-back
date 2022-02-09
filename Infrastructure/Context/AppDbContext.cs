using Domain.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Project>()
                .HasMany(e => e.Subjects)
                .WithOne(e => e.Project);

            modelBuilder
                .Entity<Subject>()
                .HasOne(e => e.Project)
                .WithMany(e => e.Subjects)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}