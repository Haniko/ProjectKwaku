using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class ChecklistType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChecklistTypeId { get; set; }

        public string Name { get; set; }
    }
}
