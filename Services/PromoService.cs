using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Business;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ubiety.Dns.Core.Records;

namespace GoingTo_API.Services
{
    public class PromoService : IPromoService
    {
        private readonly IPromoRepository _promoRepository;
        private readonly ILocatablePromoRepository _locatablePromoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PromoService(IPromoRepository promoRepository,ILocatablePromoRepository locatablePromoRepository ,IUnitOfWork unitOfWork)
        {
            _promoRepository = promoRepository;
            _locatablePromoRepository = locatablePromoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PromoResponse> DeleteAsync(int id)
        {
            var existingPromo = await _promoRepository.FindById(id);
            if (existingPromo == null)
                return new PromoResponse("Promo not found");
            try
            {
                _promoRepository.Remove(existingPromo);
                await _unitOfWork.CompleteAsync();

                return new PromoResponse(existingPromo);
            }
            catch(Exception ex)
            {
                return new PromoResponse($"An error ocurred while deleting Promo: {ex.Message}");
            }
        }

        public async Task<PromoResponse> GetByIdAsync(int id)
        {
            var existingPromo = await _promoRepository.FindById(id);
            if (existingPromo == null)
                return new PromoResponse("Promo not found");
            return new PromoResponse(existingPromo);

        }

        public async Task<IEnumerable<Promo>> ListAsync()
        {
            return await _promoRepository.ListAsync();
        }

        public async Task<IEnumerable<Promo>> ListByLocatableId(int locatableId)
        {
            var locatablePromo = await _locatablePromoRepository.ListByLocatableIdAsync(locatableId);
            var promos = locatablePromo.Select(p => p.Promo).ToList();
            return promos;
        }

        public async Task<IEnumerable<Promo>> ListPromoByPartnerId(int partnerId)
        {
            return await _promoRepository.FindByPartnerId(partnerId);

        }

        public async Task<PromoResponse> SaveAsync(Promo promo)
        {
            try
            {
                await _promoRepository.AddAsync(promo);
                await _unitOfWork.CompleteAsync();

                return new PromoResponse(promo);
            }
            catch(Exception ex)
            {
                return new PromoResponse($"An error ocurred while saving the Promo: {ex.Message}");
            }
        }

        public async Task<PromoResponse> UpdateAsync(int id, Promo promo)
        {
            var existingPromo = await _promoRepository.FindById(id);
            if (existingPromo == null)
                return new PromoResponse("Promo not found");
            existingPromo.Discount = promo.Discount;
            existingPromo.Text = promo.Text;

            try
            {
                _promoRepository.Update(existingPromo);
                await _unitOfWork.CompleteAsync();

                return new PromoResponse(existingPromo);
            }
            catch(Exception ex)
            {
                return new PromoResponse($"An error ocurred while updating the Promo:{ex.Message}");
            }
        }
    }
}
