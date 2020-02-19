using Models.Dto;
using System;
using System.Collections.Generic;

namespace Models.Dtos
{
    public class CheckSheetDto
    {
        public int CheckSheetTypeId { get; set; }

        public string CheckSheetName { get; set; }

        public DateTime StartDateUtc { get; set; }

        public string DisplayDate { get; set; }

        public IEnumerable<TaskDto> Tasks { get; set; }
    }
}
