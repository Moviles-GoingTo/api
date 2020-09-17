using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class UserAchievementRepository : BaseRepository, IUserAchievementRepository
    {
        public UserAchievementRepository(AppDbContext context) : base(context) { }
       
        public async Task AddAsync(UserAchievement userAchievement)
        {
            await _context.UserAchievements.AddAsync(userAchievement);
        }

        public async Task AssignUserAchievement(int userId, int achievementId)
        {

            UserAchievement userAchievement = await FindByUserIdAndAchievementId(userId, achievementId);
            if (userAchievement == null) 
            {
                userAchievement = new UserAchievement { UserId = userId, AchievementId = achievementId };
                await AddAsync(userAchievement);
            }        
        }

        public async Task<UserAchievement> FindByUserIdAndAchievementId(int userId, int achievementId)
        {
            return await _context.UserAchievements.FindAsync(userId, achievementId);
        }

        public async Task<IEnumerable<UserAchievement>> ListAsync()
        {
            return await _context.UserAchievements
                .Include(ua => ua.User)
                .Include(ua => ua.Achievement)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserAchievement>> ListByUserIdAsync(int userId)
        {
            return await _context.UserAchievements
                .Where(ua => ua.UserId == userId)
                .Include(ua => ua.User)
                .Include(ua => ua.Achievement)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserAchievement>> ListByAchievementIdAsync(int achievementId)
        {
            return await _context.UserAchievements
                .Where(ua => ua.AchievementId == achievementId)
                .Include(ua => ua.User)
                .Include(ua => ua.Achievement)
                .ToListAsync();
        }

        public void Remove(UserAchievement userAchievements)
        {
            _context.UserAchievements.Remove(userAchievements);
        }

        public async void UnassignUserAchievement(int userId, int achievementId)
        {
            UserAchievement userAchievements = await FindByUserIdAndAchievementId(userId, achievementId);
            if (userAchievements != null)
            {
                Remove(userAchievements);
            }
        }
    }
}
