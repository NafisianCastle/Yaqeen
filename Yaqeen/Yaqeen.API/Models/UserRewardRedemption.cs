namespace Yaqeen.API.Models
{
    public class UserRewardRedemption
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int RewardId { get; set; }
        public Reward Reward { get; set; }

        public DateTime RedemptionDate { get; set; }
        public RedemptionStatus Status { get; set; }

        public string ShippingAddress { get; set; } // Encrypted externally
    }
}