using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class UserAchievementResponse : BaseResponse<UserAchievement>
    {
        public UserAchievementResponse(UserAchievement userAchievement) : base(userAchievement) { }

        public UserAchievementResponse(string message) : base(message) { }
    }
}
