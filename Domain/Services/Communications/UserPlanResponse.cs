using GoingTo_API.Domain.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class UserPlanResponse : BaseResponse<PlanUser>
    {
        public UserPlanResponse(PlanUser userPlan) : base(userPlan) { }
        public UserPlanResponse(string message) : base(message) { }
    }
}
