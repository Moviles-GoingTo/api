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
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserPlanRepository _userPlanRepository;

        public PlanService(IPlanRepository planRepository, IUnitOfWork unitOfWork, IUserPlanRepository userPlanRepository)
        {
            _planRepository = planRepository;
            _unitOfWork = unitOfWork;
            _userPlanRepository = userPlanRepository;
        }

        public async Task<PlanResponse> DeleteAsync(int id)
        {
            var existingPlan = await _planRepository.FindById(id);

            if (existingPlan == null)
                return new PlanResponse("Plan not found");
            try
            {
                _planRepository.Remove(existingPlan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(existingPlan);
            }
            catch(Exception ex)
            {
                return new PlanResponse($"An error ocurred while deleting plan {ex.Message}");
            }
        }

        public async Task<PlanResponse> GetByIdAsync(int id)
        {
            var existingPlan = await _planRepository.FindById(id);

            if (existingPlan == null)
                return new PlanResponse("Plan not found");
            return new PlanResponse(existingPlan);
        }

        public async Task<IEnumerable<Plan>> ListAsync()
        {
            return await _planRepository.ListAsync();
        }

        public async Task<IEnumerable<Plan>> ListByUserIdAsync(int userId)
        {
            var userPlan = await _userPlanRepository.ListByPlanIdAsync(userId);
            var plans = userPlan.Select(p => p.Plan).ToList();
            return plans;
        }

        public async Task<PlanResponse> SaveAsync(Plan plan)
        {
            try
            {
                await _planRepository.AddAsync(plan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(plan);
            }
            catch(Exception ex)
            {
                return new PlanResponse($"An error ocurred while saving the plan {ex.Message}");
            }
        }

        public async Task<PlanResponse> UpdateAsync(int id, Plan plan)
        {
            var existingPlan = await _planRepository.FindById(id);

            if (existingPlan == null)
                return new PlanResponse("Plan not found");
            existingPlan.Name = plan.Name;

            try
            {
                _planRepository.Update(existingPlan);
                await _unitOfWork.CompleteAsync();

                return new PlanResponse(existingPlan);
            }
            catch(Exception ex)
            {
                return new PlanResponse($"An error ocurred while updating the plan {ex.Message}");
            }
        }
    }
}
