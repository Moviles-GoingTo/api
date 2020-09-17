using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories
{
    public interface IUserAchievementRepository
    {
        Task<IEnumerable<UserAchievement>> ListAsync();
        Task<IEnumerable<UserAchievement>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserAchievement>> ListByAchievementIdAsync(int achievementId);
        Task<UserAchievement> FindByUserIdAndAchievementId(int userId, int achievementId);
        Task AddAsync(UserAchievement userAchievement);
        void Remove(UserAchievement userAchievement);
        Task AssignUserAchievement(int userId, int achievementId);
        void UnassignUserAchievement(int userId, int achievementId);
    }
}
