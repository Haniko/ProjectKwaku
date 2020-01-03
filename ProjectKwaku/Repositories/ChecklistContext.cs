using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Repositories
{
    public class ChecklistContext : DbContext
    {
        public ChecklistContext(DbContextOptions<ChecklistContext> options) : base(options)
        {
        }

        public DbSet<Checklist> Checklists { get; set; }

        public DbSet<ChecklistType> ChecklistTypes { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskStatus> TaskStatuses { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
