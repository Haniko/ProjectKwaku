using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Task
    {
        public int TaskId { get; set; }

        [ForeignKey("ChecklistType")]
        public int? ChecklistTypeId { get; set; }

        public virtual ChecklistType ChecklistType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int ActiveDays { get; set; }

        public string TimeFrame { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
