namespace Models.Dtos
{
    public class CheckSheetSummaryDto
    {
        public string CheckSheetName { get; set; }

        public int CheckSheetTypeId { get; set; }

        public int CompletedCount { get; set; }

        public int InProgressCount { get; set; }

        public int NotStartedCount { get; set; }
    }
}
