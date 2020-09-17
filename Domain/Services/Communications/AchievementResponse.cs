using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class AchievementResponse : BaseResponse<Achievement>
    {
        public AchievementResponse(Achievement achievement) : base(achievement) { }

        public AchievementResponse(string message) : base(message) { }
    }
}
