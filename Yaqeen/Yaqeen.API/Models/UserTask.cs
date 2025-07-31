namespace Yaqeen.API.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public string? ContentReference { get; set; }

        public int? TaskScheduleId { get; set; }
        public TaskSchedule TaskSchedule { get; set; }

        public ICollection<TaskLevel> TaskLevels { get; set; }
        public ICollection<UserProgress> UserProgresses { get; set; }
    }
}