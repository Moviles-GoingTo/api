using GoingTo_API.Domain.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Business
{
    public interface IUserPlanRepository
    {
        Task<IEnumerable<PlanUser>> ListAsync();
        Task<IEnumerable<PlanUser>> ListByUserIdAsync(int userId);
        Task<IEnumerable<PlanUser>> ListByPlanIdAsync(int planId);
        Task<PlanUser> FindByUserIdAndPlanId(int userId, int planId);
        Task AddAsync(PlanUser userPlan);
        void Remove(PlanUser userPlan);
        Task AssignUserPlan(int userId, int planId);
        void UnassignUserPlan(int userId, int achivementId);


    }
}
