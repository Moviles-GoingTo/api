using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Business;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Domain.Services.Communications;

namespace GoingTo_API.Services
{
    public class LocatablePromoService : ILocatablePromoService
    {
        private readonly ILocatablePromoRepository _locatablePromoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LocatablePromoService(ILocatablePromoRepository locatablePromoRepository,IUnitOfWork unitOfWork)
        {
            _locatablePromoRepository = locatablePromoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LocatablePromoResponse> AssignLocatablePromoAsync(int locatableId, int promoId)
        {
            try
            {
                await _locatablePromoRepository.AssignLocatablePromo(locatableId, promoId);
                await _unitOfWork.CompleteAsync();
                LocatablePromo locatablePromo = await _locatablePromoRepository.FindByLocatableIdAndPromoId(locatableId, promoId);
                return new LocatablePromoResponse(locatablePromo);
            }
            catch (Exception ex)
            {
                return new LocatablePromoResponse($"An error ocurred while assigning Promo to Locatable: {ex.Message}");
            }
        }

        public async Task<IEnumerable<LocatablePromo>> ListAsync()
        {
            return await _locatablePromoRepository.ListAsync();
        }

        public async Task<IEnumerable<LocatablePromo>> ListByLocatableIdAsync(int locatableId)
        {
            return await _locatablePromoRepository.ListByLocatableIdAsync(locatableId);
        }

        public async Task<IEnumerable<LocatablePromo>> ListByPromoIdAsync(int promoId)
        {
            return await _locatablePromoRepository.ListByPromoIdAsync(promoId);
        }

        public async Task<LocatablePromoResponse> UnassignLocatablePromoAsync(int locatableId, int promoId)
        {
            try
            {
                LocatablePromo locatablePromo = await _locatablePromoRepository.FindByLocatableIdAndPromoId(locatableId, promoId);
                _locatablePromoRepository.Remove(locatablePromo);
                await _unitOfWork.CompleteAsync();
                return new LocatablePromoResponse(locatablePromo);
            }
            catch (Exception ex)
            {
                return new LocatablePromoResponse($"An error ocurred while unassigning Promo to Locatable: {ex.Message}");
            }
        }
    }
}
