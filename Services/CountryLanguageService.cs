using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Geographic;
using GoingTo_API.Domain.Services.Communications;
using GoingTo_API.Domain.Services.Geographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class CountryLanguageService : ICountryLanguageService
    {
        private readonly ICountryLanguageRepository _countryLanguageRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CountryLanguageService(ICountryLanguageRepository countryLanguageRepository, IUnitOfWork unitOfWork)
        {
            _countryLanguageRepository = countryLanguageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CountryLanguage>> ListAsync()
        {
            return await _countryLanguageRepository.ListAsync();
        }

        public async Task<IEnumerable<CountryLanguage>> ListByCountryIdAsync(int countryId)
        {
            return await _countryLanguageRepository.ListByCountryIdAsync(countryId);
        }

        public async Task<IEnumerable<CountryLanguage>> ListByLanguageIdAsync(int languageId)
        {
            return await _countryLanguageRepository.ListByLanguageIdAsync(languageId);
        }

        public async Task<CountryLanguageResponse> AssignCountryLanguageAsync(int countryId, int languageId)
        {
            try
            {

                await _countryLanguageRepository.AssignCountryLanguage(countryId, languageId);
                await _unitOfWork.CompleteAsync();
                CountryLanguage CountryLanguage = await _countryLanguageRepository.FindByCountryIdAndLanguageId(countryId, languageId);
                return new CountryLanguageResponse(CountryLanguage);
            }
            catch (Exception ex)
            {
                return new CountryLanguageResponse($"An error ocurred while assigning Language to Country: {ex.Message}");
            }
        }

        public async Task<CountryLanguageResponse> UnassignCountryLanguageAsync(int countryId, int languageId)
        {
            try
            {
                CountryLanguage countryLanguage = await _countryLanguageRepository.FindByCountryIdAndLanguageId(countryId, languageId);
                _countryLanguageRepository.Remove(countryLanguage);
                await _unitOfWork.CompleteAsync();
                return new CountryLanguageResponse(countryLanguage);
            }
            catch (Exception ex)
            {
                return new CountryLanguageResponse($"An error ocurred while unassigning Language to Country: {ex.Message}");
            }
        }
    }
}
