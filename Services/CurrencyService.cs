using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Geographic;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Communications;
using GoingTo_API.Domain.Services.Geographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICountryCurrencyRepository _countryCurrencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository, IUnitOfWork unitOfWork, ICountryCurrencyRepository countryCurrencyRepository)
        {
            _currencyRepository = currencyRepository;
            _unitOfWork = unitOfWork;
            _countryCurrencyRepository = countryCurrencyRepository;
        }

        public async Task<CurrencyResponse> DeleteAsync(int id)
        {
            var existingCurrency = await _currencyRepository.FindById(id);

            if (existingCurrency == null)
                return new CurrencyResponse("Currency not found");
            try
            {
                _currencyRepository.Remove(existingCurrency);
                await _unitOfWork.CompleteAsync();

                return new CurrencyResponse(existingCurrency);
            }
            catch(Exception ex)
            {
                return new CurrencyResponse($"An error ocurred while removing currency: {ex.Message}");
            }
        }

        public async Task<CurrencyResponse> GetByIdAsync(int id)
        {
            var existingCurrency = await _currencyRepository.FindById(id);
            if (existingCurrency == null)
                return new CurrencyResponse("Currency not found");
            return new CurrencyResponse(existingCurrency);
        }

        public async Task<IEnumerable<Currency>> ListAsync()
        {
           return await _currencyRepository.ListAsync();
        }

        public async Task<IEnumerable<Currency>> ListByCountryIdAsync(int countryId)
        {
            var countryCurrencies = await _countryCurrencyRepository.ListByCountryAsync(countryId);
            var currencies = countryCurrencies.Select(cc => cc.Currency).ToList();
            return currencies;
        }

        public async Task<CurrencyResponse> SaveAsync(Currency currency)
        {
            try
            {
                await _currencyRepository.AddAsync(currency);
                await _unitOfWork.CompleteAsync();

                return new CurrencyResponse(currency);
            }
            catch(Exception ex)
            {
                return new CurrencyResponse($"An error ocurred while saving currency: {ex.Message}");
            }
        }

        public async Task<CurrencyResponse> UpdateAsync(int id, Currency currency)
        {
            var existingCurrency = await _currencyRepository.FindById(id);
            if (existingCurrency == null)
                return new CurrencyResponse("Currency not found");
            existingCurrency.ShortName = currency.ShortName;

            try
            {
                _currencyRepository.Update(existingCurrency);
                await _unitOfWork.CompleteAsync();

                return new CurrencyResponse(existingCurrency);
            }
            catch(Exception ex)
            {
                return new CurrencyResponse($"An error ocurred while updating currency: {ex.Message}");
            }
        }
    }
}
