using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Accounts;
using GoingTo_API.Domain.Services.Accounts;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class ProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _profileRepository;
        public readonly IUnitOfWork _unitOfWork;

        public ProfileService(IUserProfileRepository profileRepository, IUnitOfWork unitOfWork)
        {
            _profileRepository = profileRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task<IEnumerable<UserProfile>> ListAsync()
        {
            return await _profileRepository.ListAsync();
        }

        public async Task<ProfileResponse> SaveAsync(UserProfile profile)
        {
            try
            {
                await _profileRepository.AddAsync(profile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(profile);
            }
            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while saving the profile: {ex.Message}");
            }
        }

        public async Task<ProfileResponse> UpdateAsync(int id, UserProfile profile)
        {
            var existingProfile = await _profileRepository.FindById(id);

            if (existingProfile == null)
                return new ProfileResponse("Profile not found");

            existingProfile.Name = profile.Name;
            existingProfile.UserId = profile.UserId;
            existingProfile.Surname = profile.Surname;
            existingProfile.BirthDate = profile.BirthDate;
            existingProfile.Gender = profile.Gender;
            existingProfile.CreatedAt = profile.CreatedAt;
            existingProfile.CountryId = profile.CountryId;

            try
            {
                _profileRepository.Update(existingProfile);
                await _unitOfWork.CompleteAsync();

                return new ProfileResponse(existingProfile);
            }

            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while updating profile : {ex.Message}");
            }
        }

        public async Task<ProfileResponse> DeleteAsync(int id)
        {
            var existingProfile = await _profileRepository.FindById(id);

            if (existingProfile == null)
                return new ProfileResponse("Profile not found");

            try
            {
                _profileRepository.Remove(existingProfile);
                await _unitOfWork.CompleteAsync();
                return new ProfileResponse(existingProfile);
            }

            catch (Exception ex)
            {
                return new ProfileResponse($"An error ocurred while deleting profile : {ex.Message}");
            }
        }

        public async Task<ProfileResponse> FindById(int userProfileId)
        {
            var existingUserProfile = await _profileRepository.FindById(userProfileId);
            if (existingUserProfile == null)
                return new ProfileResponse("Profile not found");
            return new ProfileResponse(existingUserProfile);
        }
    }
}
