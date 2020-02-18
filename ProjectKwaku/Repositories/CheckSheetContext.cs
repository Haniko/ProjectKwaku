using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using System;

namespace Repositories
{
    public class CheckSheetContext : DbContext, IDbContext
    {
        private readonly string databaseConnectionString;

        public CheckSheetContext(
            DbContextOptions<CheckSheetContext> options,
            IConfiguration configuration) : base(options)
        {
            databaseConnectionString = configuration.GetConnectionString("OpsChecklistDatabase");
        }

        public DbSet<CheckSheet> CheckSheets { get; set; }

        public DbSet<CheckSheetType> CheckSheetTypes { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskStatus> TaskStatuses { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseSqlServer(databaseConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TaskStatus>()
                .HasOne(x => x.Task)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
