using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GoingTo_API.Domain.Models.Accounts
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public Wallet Wallet { get; set; }

        public int? WalletId { get; set; }
        public UserProfile Profile { get; set; }
        public List<Favourite> Favourites { get; set; } = new List<Favourite>();
        public List<UserAchievement> UserAchievements { get; set; } = new List<UserAchievement>();
        public List<PlanUser> UserPlans { get; set; }
    
    }
}
