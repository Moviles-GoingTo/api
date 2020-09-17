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
    public class EstateService : IEstateService
    {
        private readonly IEstateRepository _estateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EstateService(IEstateRepository estateRepository, IUnitOfWork unitOfWork)
        {
            _estateRepository = estateRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EstateResponse> DeleteAsync(int id)
        {
            var existingEstate = await _estateRepository.FindById(id);
            if (existingEstate == null)
                return new EstateResponse("Estate not found");
            try
            {
                _estateRepository.Remove(existingEstate);
                await _unitOfWork.CompleteAsync();

                return new EstateResponse(existingEstate);
            }
            catch (Exception ex)
            {
                return new EstateResponse($"An error ocurred while deleting Estate: {ex.Message}");
            }
        }

        public async Task<EstateResponse> GetByIdAsync(int id)
        {
            var existingEstate = await _estateRepository.FindById(id);
            if (existingEstate == null)
                return new EstateResponse("Estate not found");
            return new EstateResponse(existingEstate);
        }

        public async Task<IEnumerable<Estate>> ListAsync()
        {
            return await _estateRepository.ListAsync();
        }

        public async Task<IEnumerable<Estate>> ListByPartnerNameAsync(string partnerName)
        {
            return await _estateRepository.ListByPartnerNameAsync(partnerName);
        }

        public async Task<EstateResponse> SaveAsync(Estate estate)
        {
            try
            {
                await _estateRepository.AddAsync(estate);
                await _unitOfWork.CompleteAsync();

                return new EstateResponse(estate);
            }
            catch (Exception ex)
            {
                return new EstateResponse($"An error ocurred while saving the Estate: {ex.Message}");
            }
        }

        public async Task<EstateResponse> UpdateAsync(int id, Estate estate)
        {
            var existingEstate = await _estateRepository.FindById(id);
            if (existingEstate == null)
                return new EstateResponse("Estate not found");
            existingEstate.Name = estate.Name;
            existingEstate.Description = estate.Description;
            try
            {
                _estateRepository.Update(existingEstate);
                await _unitOfWork.CompleteAsync();

                return new EstateResponse(existingEstate);
            }
            catch (Exception ex)
            {
                return new EstateResponse($"An error ocurred while updating the Estate: {ex.Message}");
            }
        }
    }
}
