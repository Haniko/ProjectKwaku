using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Repositories
{
    public interface IDbContext
    {
        DbSet<CheckSheet> CheckSheets { get; set; }

        DbSet<CheckSheetType> CheckSheetTypes { get; set; }

        DbSet<Task> Tasks { get; set; }

        DbSet<TaskStatus> TaskStatuses { get; set; }

        DbSet<User> Users { get; set; }
    }
}
