using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Geographic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class CountryLanguageRepository : BaseRepository, ICountryLanguageRepository
    {
        public CountryLanguageRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(CountryLanguage countryLanguage)
        {
            await _context.CountryLanguages.AddAsync(countryLanguage); 
        }

        public async Task AssignCountryLanguage(int countryId, int languageId)
        {
            CountryLanguage countryLanguage = await FindByCountryIdAndLanguageId(countryId, languageId);
            if (countryLanguage == null)
            {
                countryLanguage = new CountryLanguage { CountryId = countryId, LanguageId = languageId };
                await AddAsync(countryLanguage);
            }
        }

        public async Task<CountryLanguage> FindByCountryIdAndLanguageId(int countryId, int languageId)
        {
            return await _context.CountryLanguages.FindAsync(countryId, languageId);
        }

        public async Task<IEnumerable<CountryLanguage>> ListAsync()
        {
            return await _context.CountryLanguages
             .Include(ua => ua.Country.Locatable)
             .Include(ua => ua.Language)
             .ToListAsync();
        }

        public async Task<IEnumerable<CountryLanguage>> ListByCountryIdAsync(int countryId)
        {
            return await _context.CountryLanguages
             .Where(ua => ua.CountryId == countryId)
             .Include(ua => ua.Country.Locatable)
             .Include(ua => ua.Language)
             .ToListAsync();
        }

        public async Task<IEnumerable<CountryLanguage>> ListByLanguageIdAsync(int languageId)
        {
            return await _context.CountryLanguages
           .Where(ua => ua.LanguageId == languageId)
           .Include(ua => ua.Country.Locatable)
           .Include(ua => ua.Language)
           .ToListAsync();
        }

        public void Remove(CountryLanguage countryLanguage)
        {
            _context.CountryLanguages.Remove(countryLanguage);
        }

        public async void UnassignCountryLanguage(int countryId, int languageId)
        {
            CountryLanguage countryLanguage = await FindByCountryIdAndLanguageId(countryId, languageId);
            if (countryLanguage != null)
            {
                Remove(countryLanguage);
            }
        }
    }
}
