using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class PlanBenefitResponse : BaseResponse<PlanBenefit>
    {
        public PlanBenefitResponse(PlanBenefit resource) : base(resource)
        {
        }

        public PlanBenefitResponse(string message) : base(message)
        {
        }
    }
}
