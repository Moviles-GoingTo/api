using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class UserAchievementService : IUserAchievementService
    {
        private readonly IUserAchievementRepository _userAchievementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserAchievementService(IUserAchievementRepository userAchievementRepository, IUnitOfWork unitOfWork)
        {
            _userAchievementRepository = userAchievementRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserAchievement>> ListAsync()
        {
            return await _userAchievementRepository.ListAsync();
        }

        public async Task<IEnumerable<UserAchievement>> ListByUserIdAsync(int userId)
        {
            return await _userAchievementRepository.ListByUserIdAsync(userId);
        }

        public async Task<IEnumerable<UserAchievement>> ListByAchievementIdAsync(int achievementId)
        {
            return await _userAchievementRepository.ListByAchievementIdAsync(achievementId);
        }

        public async Task<UserAchievementResponse> AssignUserAchievementAsync(int userId, int achievementId)
        {
            try
            {
                await _userAchievementRepository.AssignUserAchievement(userId, achievementId);
                await _unitOfWork.CompleteAsync();
                UserAchievement userAchievement = await _userAchievementRepository.FindByUserIdAndAchievementId(userId, achievementId);
                return new UserAchievementResponse(userAchievement);
            }
            catch (Exception ex)
            {
                return new UserAchievementResponse($"An error ocurred while assigning Achievement to User: {ex.Message}");
            }
        }

        public async Task<UserAchievementResponse> UnassignUserAchievementAsync(int userId, int achievementId)
        {
            try
            {
                UserAchievement userAchievement = await _userAchievementRepository.FindByUserIdAndAchievementId(userId, achievementId);
                _userAchievementRepository.Remove(userAchievement);
                await _unitOfWork.CompleteAsync();
                return new UserAchievementResponse(userAchievement);
            }
            catch (Exception ex)
            {
                return new UserAchievementResponse($"An error ocurred while unassigning Achievement to User: {ex.Message}");
            }
        }
    }
}