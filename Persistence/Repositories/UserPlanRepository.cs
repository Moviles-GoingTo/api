using GoingTo_API.Domain.Models.Accounts;
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
    public class UserPlanRepository : BaseRepository, IUserPlanRepository
    {
        public UserPlanRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(PlanUser userPlan)
        {
            await _context.PlanUsers.AddAsync(userPlan);
        }

        public async Task AssignUserPlan(int userId, int planId)
        {
            PlanUser userPlan = await FindByUserIdAndPlanId(userId, planId);
            if(userPlan == null)
            {
                userPlan = new PlanUser { UserId = userId, PlanId = planId };
                await AddAsync(userPlan);
            }
        }

        public async Task<PlanUser> FindByUserIdAndPlanId(int userId, int planId)
        {
            return await _context.PlanUsers.FindAsync(userId, planId);
        }

        public async Task<IEnumerable<PlanUser>> ListAsync()
        {
            return await _context.PlanUsers
                 .Include(up => up.User)
                 .Include(up => up.Plan)
                 .ToListAsync();
        }

        public async Task<IEnumerable<PlanUser>> ListByPlanIdAsync(int planId)
        {
            return await _context.PlanUsers
                .Where(up => up.PlanId == planId)
                .Include(up => up.Plan)
                .Include(up => up.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<PlanUser>> ListByUserIdAsync(int userId)
        {
            return await _context.PlanUsers
                 .Where(up => up.UserId == userId)
                 .Include(up => up.User)
                 .Include(up => up.Plan)
                 .ToListAsync();
        }

        public void Remove(PlanUser userPlan)
        {
            _context.PlanUsers.Remove(userPlan);
        }

        public async void UnassignUserPlan(int userId, int planId)
        {
            PlanUser userPlan = await FindByUserIdAndPlanId(userId, planId);
            if (userPlan != null)
                Remove(userPlan);
        }
    }
}
