using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class PlanBenefitRepository : BaseRepository, IPlanBenefitRepository
    {
        public PlanBenefitRepository(AppDbContext context) : base(context) { }
       

        public async Task AddAsync(PlanBenefit planBenefit)
        {
            await _context.PlanBenefits.AddAsync(planBenefit);
        }

        public async Task AssignPlanBenefit(int planId, int benefitId)
        {
            PlanBenefit planBenefit = await FindByPlanIdAndBenefitId (planId, benefitId);
            if (planBenefit == null)
            {
                planBenefit = new PlanBenefit { BenefitId = benefitId, PlanId = planId };
                await AddAsync(planBenefit);
            }
        }

        public async Task<PlanBenefit> FindByPlanIdAndBenefitId(int planId, int benefitId)
        {
            return await _context.PlanBenefits.FindAsync(planId, benefitId);
        }

        public async Task<IEnumerable<PlanBenefit>> ListAsync()
        {
            return await _context.PlanBenefits
                .Include(p=>p.Benefit)
                .Include(p=>p.Plan).
                ToListAsync();
        }

        public async Task<IEnumerable<PlanBenefit>> ListByBenefitIdAsync(int benefitId)
        {
            return await _context.PlanBenefits
                .Where(p => p.BenefitId == benefitId)
                .Include(p => p.Plan)
                .Include(p => p.Benefit)
                .ToListAsync();
        }

        public async Task<IEnumerable<PlanBenefit>> ListByPlanIdAsync(int planId)
        {
            return await _context.PlanBenefits
                .Where(p => p.PlanId == planId)
                .Include(p => p.Plan)
                .Include(p => p.Benefit)
                .ToListAsync();
        }

        public void Remove(PlanBenefit planBenefit)
        {
            _context.PlanBenefits.Remove(planBenefit);
        }

        public async void UnassignPlanBenefit(int planId, int benefitId)
        {
            PlanBenefit planBenefit = await FindByPlanIdAndBenefitId(planId, benefitId);
            if (planBenefit != null)
                Remove(planBenefit);
        }
    }
}
