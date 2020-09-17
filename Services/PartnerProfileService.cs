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
    public class PartnerProfileService : IPartnerProfileService
    {
        private readonly IPartnerProfileRepository _partnerProfileRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PartnerProfileService(IPartnerProfileRepository partnerProfileRepository, IUnitOfWork unitOfWork)
        {
            _partnerProfileRepository = partnerProfileRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PartnerProfileResponse> DeleteAsync(int id)
        {
            var existingPartnerProfile = await _partnerProfileRepository.FindById(id);
            if (existingPartnerProfile == null)
                return new PartnerProfileResponse("Partner Profile not found");
            try
            {
                _partnerProfileRepository.Remove(existingPartnerProfile);
                await _unitOfWork.CompleteAsync();

                return new PartnerProfileResponse(existingPartnerProfile);
            }
            catch(Exception ex)
            {
                return new PartnerProfileResponse($"An error ocurred while deleting PartnerProfile : {ex.Message}");
            }

        }

        public async Task<PartnerProfileResponse> GetByPartnerIdAsync(int partnerId)
        {
            var existingPartnerProfile = await _partnerProfileRepository.FindByPartnerId(partnerId);
            if (existingPartnerProfile == null)
                return new PartnerProfileResponse("PartnerProfile not found");
            return new PartnerProfileResponse(existingPartnerProfile);
        }

        public async Task<PartnerProfileResponse> SaveAsync(PartnerProfile partnerProfile)
        {
            try
            {
                await _partnerProfileRepository.AddAsync(partnerProfile);
                await _unitOfWork.CompleteAsync();

                return new PartnerProfileResponse(partnerProfile);
            }
            catch(Exception ex)
            {
                return new PartnerProfileResponse($"An error ocurred while saving the partner profila: {ex.Message}");
            }
        }

        public async Task<PartnerProfileResponse> UpdateAsync(int id, PartnerProfile partnerProfile)
        {
            var existingPartnerProfile = await _partnerProfileRepository.FindById(id);
            if (existingPartnerProfile == null)
                return new PartnerProfileResponse("Partner Profile not found");
            existingPartnerProfile.Address = partnerProfile.Address;
            existingPartnerProfile.Name = partnerProfile.Name;
            existingPartnerProfile.Telephone = partnerProfile.Telephone;
            try
            {
                _partnerProfileRepository.Update(existingPartnerProfile);
                await _unitOfWork.CompleteAsync();

                return new PartnerProfileResponse(existingPartnerProfile);
            }
            catch(Exception ex)
            {
                return new PartnerProfileResponse($"An error ocurred while updating the partner profile: {ex.Message}");
            }
        }
    }
}
