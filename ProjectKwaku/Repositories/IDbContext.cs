using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Repositories
{
    public interface IDbContext
    {
        DbSet<Checklist> Checklists { get; set; }

        DbSet<ChecklistType> ChecklistTypes { get; set; }

        DbSet<Task> Tasks { get; set; }

        DbSet<TaskStatus> TaskStatuses { get; set; }

        DbSet<User> Users { get; set; }
    }
}
