namespace Yaqeen.API.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointCost { get; set; }
        public RewardType Type { get; set; }
        public bool IsActive { get; set; }

        public ICollection<UserRewardRedemption> Redemptions { get; set; }
    }
}