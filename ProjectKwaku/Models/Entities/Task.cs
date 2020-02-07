using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [ForeignKey("CheckSheetType")]
        public int CheckSheetTypeId { get; set; }

        public int ActiveDays { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public TimeSpan StartTimeUtc { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public DateTime ValidFromDateUtc { get; set; }

        public DateTime? ValidUntilDateUtc { get; set; }

        public virtual CheckSheetType ChecklistType { get; set; }
    }
}
