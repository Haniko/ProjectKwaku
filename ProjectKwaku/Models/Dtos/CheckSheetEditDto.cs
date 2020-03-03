using Models.Entities;
using System.Collections.Generic;

namespace Models.Dtos
{
    public class CheckSheetEditDto
    {
        public CheckSheetType CheckSheetType { get; set; }

        public IList<Task> ActiveTasks { get; set; }
    }
}
