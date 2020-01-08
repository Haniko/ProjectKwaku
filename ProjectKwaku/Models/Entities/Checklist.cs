using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Checklist
    {
        public int ChecklistId { get; set; }

        [ForeignKey("ChecklistType")]
        public int? ChecklistTypeId { get; set; }

        [ForeignKey("SignOffUser")]
        public int? SignOffUserId { get; set; }

        public DateTime StartDate { get; set; }

        public string Comment { get; set; }

        public virtual ChecklistType ChecklistType { get; set; }

        public virtual User SignOffUser { get; set; }

        public virtual List<TaskStatus> TaskStatuses { get; set; }
    }
}
