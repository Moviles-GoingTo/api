using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class PlanResponse : BaseResponse<Plan>
    {
        public PlanResponse(Plan plan) : base(plan)
        {
        }

        public PlanResponse(string message) : base(message)
        {
        }
    }
}
