namespace Models.Dto
{
    public class TaskDto
    {
        public int TaskId { get; set; }

        public string AssignedUserName { get; set; }

        public string Status { get; set; }

        public string DisplayTime { get; set; }

        public string TaskComment { get; set; }

        public string TaskDescription { get; set; }

        public string TaskNotes { get; set; }

        public string TaskTitle { get; set; }

        public string Url { get; set; }
    }
}