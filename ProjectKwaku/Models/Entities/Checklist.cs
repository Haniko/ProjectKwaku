using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Checklist
    {
        public int ChecklistId { get; set; }

        [ForeignKey("ChecklistType")]
        public int? ChecklistTypeId { get; set; }

        public virtual ChecklistType ChecklistType { get; set; }

        public User SignOffUser { get; set; }

        public DateTime StartDate { get; set; }

        public string Comment { get; set; }
    }
}
