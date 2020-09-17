using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Business
{
    public interface IPlanBenefitService
    {
        Task<IEnumerable<PlanBenefit>> ListAsync();
        Task<IEnumerable<PlanBenefit>> ListByBenefitIdAsync(int benefitId);
        Task<IEnumerable<PlanBenefit>> ListByPlanIdAsync(int planId);
        Task<PlanBenefitResponse> AssignPlanBenefitAsync(int planId, int benefitId);
        Task<PlanBenefitResponse> UnassignPlanBenefitAsync(int planId, int benefitId);
    }
}
