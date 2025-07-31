namespace Yaqeen.API.Models
{
    public class UserProgress
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TaskId { get; set; }
        public UserTask Task { get; set; }

        public DateTime  CompletionDate { get; set; }
        public int PointsAwarded { get; set; }
    }
}