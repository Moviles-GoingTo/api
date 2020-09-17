using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Business
{
    public interface IPlanBenefitRepository
    {
        Task<IEnumerable<PlanBenefit>> ListAsync();
        Task<IEnumerable<PlanBenefit>> ListByPlanIdAsync(int planId);
        Task<IEnumerable<PlanBenefit>> ListByBenefitIdAsync(int benefitId);
        Task<PlanBenefit> FindByPlanIdAndBenefitId(int planId, int benefitId);
        Task AddAsync(PlanBenefit planBenefit);
        void Remove(PlanBenefit planBenefit);
        Task AssignPlanBenefit(int planId, int benefitId);
        void UnassignPlanBenefit(int planId, int benefitId);
    }
}
