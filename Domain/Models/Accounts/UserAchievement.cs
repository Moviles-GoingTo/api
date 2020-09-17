using GoingTo_API.Domain.Models.Accounts;

namespace GoingTo_API.Domain.Models
{
    public class UserAchievement

    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public User User { get; set; }
        public Achievement Achievement { get; set; }
    }
}
