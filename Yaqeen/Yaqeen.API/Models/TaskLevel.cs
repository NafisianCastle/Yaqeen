namespace Yaqeen.API.Models
{
    public class TaskLevel
    {
        public int TaskId { get; set; }
        public Level Level { get; set; }

        public UserTask Task { get; set; }
    }
}