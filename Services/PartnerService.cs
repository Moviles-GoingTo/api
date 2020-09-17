using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Accounts;
using GoingTo_API.Domain.Services.Accounts;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PartnerService(IPartnerRepository partnerRepository, IUnitOfWork unitOfWork)
        {
            _partnerRepository = partnerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PartnerResponse> DeleteAsync(int id)
        {
            var existingPartner = await _partnerRepository.FindById(id);
            if (existingPartner == null)
                return new PartnerResponse("Partner not found");
            try
            {
                _partnerRepository.Remove(existingPartner);
                await _unitOfWork.CompleteAsync();

                return new PartnerResponse(existingPartner);
            }
            catch(Exception ex)
            {
                return new PartnerResponse($"An error ocurred while deleting Partner {ex.Message}");
            }
        }

        public async Task<PartnerResponse> GetByIdAsync(int id)
        {
            var existingPartner = await _partnerRepository.FindById(id);

            if (existingPartner == null)
                return new PartnerResponse("Partner not found");
            return new PartnerResponse(existingPartner);
        }

        public async Task<IEnumerable<Partner>> ListAsync()
        {
            return await _partnerRepository.ListAsync();
        }

        public async Task<PartnerResponse> SaveAsync(Partner partner)
        {
            try
            {
                await _partnerRepository.AddAsync(partner);
                await _unitOfWork.CompleteAsync();

                return new PartnerResponse(partner);
            }
            catch(Exception ex)
            {
                return new PartnerResponse($"An error ocurred while saving the partner: {ex.Message}");
            }
        }

        public async Task<PartnerResponse> UpdateAsync(int id, Partner partner)
        {
            var existingPartner = await _partnerRepository.FindById(id);
            if (existingPartner == null)
                return new PartnerResponse("Partner not found");
            existingPartner.Name = partner.Name;
            try
            {
                _partnerRepository.Update(existingPartner);
                await _unitOfWork.CompleteAsync();

                return new PartnerResponse(existingPartner);
            }
            catch(Exception ex)
            {
                return new PartnerResponse($"An error ocurred while updating the partner: {ex.Message}");
            }
        }
    }
}
