namespace Yaqeen.API.Models
{

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string GoogleId { get; set; }
        public string FullName { get; set; }
        public Level CurrentLevel { get; set; }
        public int PointsBalance { get; set; }

        public ICollection<UserProgress> UserProgresses { get; set; }
        public ICollection<CustomUserTask> CustomUserTasks { get; set; }
        public ICollection<UserRewardRedemption> RewardRedemptions { get; set; }
    }
}