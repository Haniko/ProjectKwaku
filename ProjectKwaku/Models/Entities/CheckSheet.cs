using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class CheckSheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CheckSheetId { get; set; }

        [ForeignKey("CheckSheetType")]
        public int CheckSheetTypeId { get; set; }

        [ForeignKey("SignOffUser")]
        public int? SignOffUserId { get; set; }

        public DateTime StartDateUtc { get; set; }

        public string Comment { get; set; }

        public virtual CheckSheetType CheckSheetType { get; set; }

        public virtual User SignOffUser { get; set; }

        public virtual List<TaskStatus> TaskStatuses { get; set; }
    }
}
