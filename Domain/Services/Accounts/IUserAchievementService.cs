using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services
{
    public interface IUserAchievementService
    {
        Task<IEnumerable<UserAchievement>> ListAsync();
        Task<IEnumerable<UserAchievement>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserAchievement>> ListByAchievementIdAsync(int achievementId);
        Task<UserAchievementResponse> AssignUserAchievementAsync(int userId, int achievementId);
        Task<UserAchievementResponse> UnassignUserAchievementAsync(int userId, int achievementId);
    }
}
