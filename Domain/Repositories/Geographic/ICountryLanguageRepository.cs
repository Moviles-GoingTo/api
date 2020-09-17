using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Geographic
{
    public interface ICountryLanguageRepository
    {
        Task<IEnumerable<CountryLanguage>> ListAsync();
        Task<IEnumerable<CountryLanguage>> ListByCountryIdAsync(int countryId);
        Task<IEnumerable<CountryLanguage>> ListByLanguageIdAsync(int languageId);
        Task<CountryLanguage> FindByCountryIdAndLanguageId(int countryId, int languageId);
        Task AddAsync(CountryLanguage countryLanguage);
        void Remove(CountryLanguage countryLanguage);
        Task AssignCountryLanguage(int countryId, int languageId);
        void UnassignCountryLanguage(int countryId, int languageId);
    }
}
