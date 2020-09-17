using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Accounts
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
        public List<UserAchievement> UserAchievements { get; set; }
    }
}

