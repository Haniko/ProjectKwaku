using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class CheckSheetType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CheckSheetTypeId { get; set; }

        public string Name { get; set; }

        public string TimeZoneId { get; set; }
    }
}
