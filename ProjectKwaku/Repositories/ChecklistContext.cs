using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;

namespace Repositories
{
    public class ChecklistContext : DbContext, IDbContext
    {
        private readonly string databaseConnectionString;

        public ChecklistContext(
            DbContextOptions<ChecklistContext> options,
            IConfiguration configuration) : base(options)
        {
            databaseConnectionString = configuration.GetConnectionString("OpsChecklistDatabase");
        }

        public DbSet<Checklist> Checklists { get; set; }

        public DbSet<ChecklistType> ChecklistTypes { get; set; }

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

        }
    }
}
