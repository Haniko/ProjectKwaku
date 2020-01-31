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
            builder.Entity<TaskStatus>()
                .HasOne(x => x.Task)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ChecklistType>().HasData(
                new ChecklistType { ChecklistTypeId = 1, Name = "EMEA" },
                new ChecklistType { ChecklistTypeId = 2, Name = "Oceania" }
            );

            builder.Entity<Task>().HasData(
                new Task
                {
                    TaskId = 1,
                    ChecklistTypeId = 1,
                    Name = "Do some task",
                    Description = "this task requires xyz",
                    Url = "",
                    ActiveDays = (int)(DaysOfWeek.Monday | DaysOfWeek.Tuesday),
                    TimeFrame = "1800-2000",
                    StartDate = new System.DateTime(2019, 1, 1),
                    EndDate = null
                },
                new Task
                {
                    TaskId = 2,
                    ChecklistTypeId = 2,
                    Name = "Do some task 2",
                    Description = "this task requires xyz 2",
                    Url = "",
                    ActiveDays = (int)(DaysOfWeek.Monday | DaysOfWeek.Tuesday),
                    TimeFrame = "1200-2000",
                    StartDate = new System.DateTime(2019, 1, 1),
                    EndDate = null
                }
            );

            builder.Entity<Checklist>().HasData(
                new Checklist
                {
                    ChecklistId = 1,
                    ChecklistTypeId = 1,
                    SignOffUserId = null,
                    StartDate = new System.DateTime(2019, 1, 1),
                    Comment = ""
                },
                new Checklist
                {
                    ChecklistId = 2,
                    ChecklistTypeId = 2,
                    SignOffUserId = null,
                    StartDate = new System.DateTime(2019, 1, 1),
                    Comment = ""
                }
            );;

            builder.Entity<TaskStatus>().HasData(
                new TaskStatus
                {
                    TaskStatusId = 1,
                    ChecklistId = 1,
                    TaskId = 1,
                    Comment = "",
                    AssignedUserId = null,
                    State = State.None
                },
                new TaskStatus
                {
                    TaskStatusId = 2,
                    ChecklistId = 2,
                    TaskId = 2,
                    Comment = "",
                    AssignedUserId = null,
                    State = State.None
                }
            );
        }
    }
}
