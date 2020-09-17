using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services
{
    public interface IAchievementService
    {
        Task<IEnumerable<Achievement>> ListAsync();
        Task<IEnumerable<Achievement>> ListByUserIdAsync(int userId);
        Task<AchievementResponse> GetByIdAsync(int id);
        Task<AchievementResponse> SaveAsync(Achievement achievement);
        Task<AchievementResponse> UpdateAsync(int id, Achievement achievement);
        Task<AchievementResponse> DeleteAsync(int id);
    }
}
