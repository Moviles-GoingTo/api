using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class AchievementService : IAchievementService

    {
        private readonly IAchievementRepository _achievementRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAchievementRepository _userAchievementRepository;

        public AchievementService(IAchievementRepository achievementRepository, IUnitOfWork unitOfWork, IUserAchievementRepository userAchievementRepository)
        {
            _achievementRepository = achievementRepository;
            _unitOfWork = unitOfWork;
            _userAchievementRepository = userAchievementRepository;
        }

        public async Task<AchievementResponse> DeleteAsync(int id)
        {
            var existingAchievement = await _achievementRepository.FindById(id);

            if (existingAchievement == null)
                return new AchievementResponse("Achievement not found");

            try
            {
                _achievementRepository.Remove(existingAchievement);
                await _unitOfWork.CompleteAsync();

                return new AchievementResponse(existingAchievement);
            }
            catch (Exception ex)
            {
                return new AchievementResponse($"An error ocurred while deleting achievement: {ex.Message}");
            }
        }

        public async Task<AchievementResponse> GetByIdAsync(int id)
        {
            var existingAchievement = await _achievementRepository.FindById(id);

            if (existingAchievement == null)
                return new AchievementResponse("Achievement not found");
            return new AchievementResponse(existingAchievement);
        }

        public async Task<IEnumerable<Achievement>> ListAsync()
        {
            return await _achievementRepository.ListAsync();
        }

        public async Task<IEnumerable<Achievement>> ListByUserIdAsync(int userId)
        {
            var userAchievement = await _userAchievementRepository.ListByUserIdAsync(userId);
            var achievements = userAchievement.Select(pt => pt.Achievement).ToList();
            return achievements;
        }

        public async Task<AchievementResponse> SaveAsync(Achievement achievement)
        {
            try
            {
                await _achievementRepository.AddAsync(achievement);
                await _unitOfWork.CompleteAsync();

                return new AchievementResponse(achievement);
            }
            catch (Exception ex)
            {
                return new AchievementResponse($"An error ocurred while saving the achievement: {ex.Message}");
            }
        }

        public async Task<AchievementResponse> UpdateAsync(int id, Achievement achievement)
        {
            var existingAchievement = await _achievementRepository.FindById(id);

            if (existingAchievement == null)
                return new AchievementResponse("Achievement not found");

            existingAchievement.Text = achievement.Text;
            existingAchievement.Points = achievement.Points;

            try
            {
                _achievementRepository.Update(existingAchievement);
                await _unitOfWork.CompleteAsync();

                return new AchievementResponse(existingAchievement);
            }
            catch (Exception ex)
            {
                return new AchievementResponse($"An error ocurred while updating achievement: {ex.Message}");
            }
        }
    }
}
