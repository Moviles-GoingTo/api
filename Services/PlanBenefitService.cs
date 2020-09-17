using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Business;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class PlanBenefitService : IPlanBenefitService
    {
        private readonly IPlanBenefitRepository _planBenefitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlanBenefitService(IPlanBenefitRepository planBenefitRepository, IUnitOfWork unitOfWork)
        {
            _planBenefitRepository = planBenefitRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PlanBenefit>> ListAsync()
        {
            return await _planBenefitRepository.ListAsync();
        }

        public async Task<IEnumerable<PlanBenefit>> ListByBenefitIdAsync(int benefitId)
        {
            return await _planBenefitRepository.ListByBenefitIdAsync(benefitId);
        }

        public async Task<IEnumerable<PlanBenefit>> ListByPlanIdAsync(int planId)
        {
            return await _planBenefitRepository.ListByPlanIdAsync(planId); 
        }


        public async Task<PlanBenefitResponse> AssignPlanBenefitAsync(int planId, int benefitId)
        {
            try
            {
                await _planBenefitRepository.AssignPlanBenefit(planId, benefitId);
                await _unitOfWork.CompleteAsync();
                PlanBenefit planBenefit = await _planBenefitRepository.FindByPlanIdAndBenefitId(planId,benefitId);

                return new PlanBenefitResponse(planBenefit);
            }
            catch (Exception ex)
            {
                return new PlanBenefitResponse($"An error ocurred while assigning Benefit to Plan {ex.Message}");
            }
        }

        public async Task<PlanBenefitResponse> UnassignPlanBenefitAsync(int planId, int benefitId)
        {
            try
            {
                PlanBenefit planBenefit = await _planBenefitRepository.FindByPlanIdAndBenefitId(planId, benefitId);
                _planBenefitRepository.Remove(planBenefit);
                await _unitOfWork.CompleteAsync();

                return new PlanBenefitResponse(planBenefit);
            }
            catch (Exception ex)
            {
                return new PlanBenefitResponse($"An error ocurred while unnasigning Benefit to Plan {ex.Message}");
            }
        }
    }
}
