using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Geographic;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICountryLanguageRepository _countryLanguageRepository;
        public LanguageService(ILanguageRepository languageRepository, IUnitOfWork unitOfWork, ICountryLanguageRepository countryLanguageRepository)
        {
            _languageRepository = languageRepository;
            _unitOfWork = unitOfWork;
            _countryLanguageRepository = countryLanguageRepository;
        }

        public async Task<LanguageResponse> GetByIdAsync(int id)
        {
            var existingLanguage = await _languageRepository.FindById(id);

            if (existingLanguage == null)
                return new LanguageResponse("Language not found");
            return new LanguageResponse(existingLanguage);
        }

        public async Task<IEnumerable<Language>> ListAsync()
        {
            return await _languageRepository.ListAsync();
        }

        public async Task<IEnumerable<Language>> ListByCountryIdAsync(int countryId)
        {
            var countryLanguage = await _countryLanguageRepository.ListByCountryIdAsync(countryId);
            var languages = countryLanguage.Select(pt => pt.Language).ToList();
            return languages;
        }

        public async Task<LanguageResponse> SaveAsync(Language language)
        {
            try
            {
                await _languageRepository.AddAsync(language);
                await _unitOfWork.CompleteAsync();

                return new LanguageResponse(language);
            }
            catch (Exception ex)
            {
                return new LanguageResponse($"An error ocurred while saving the Language: {ex.Message}");
            }
        }

        public async Task<LanguageResponse> UpdateAsync(int id, Language language)
        {
            var existingLanguage = await _languageRepository.FindById(id);

            if (existingLanguage == null)
                return new LanguageResponse("Language not found");

            existingLanguage.ShortName = language.ShortName;
            existingLanguage.FullName = language.FullName;


            try
            {
                _languageRepository.Update(existingLanguage);
                await _unitOfWork.CompleteAsync();

                return new LanguageResponse(existingLanguage);
            }
            catch (Exception ex)
            {
                return new LanguageResponse($"An error ocurred while updating Language: {ex.Message}");
            }
        }
    }
}

