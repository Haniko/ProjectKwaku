using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public enum State
    {
        None = 0,
        InProgress = 1,
        Completed = 2
    }

    public class TaskStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskStatusId { get; set; }

        public int CheckSheetId { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }

        [ForeignKey("User")]
        public int? AssignedUserId { get; set; }

        public string Comment { get; set; }

        public State State { get; set; }

        public virtual Task Task { get; set; }

        public virtual User AssignedUser { get; set; }
    }
}
