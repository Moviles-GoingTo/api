using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Geographic
{
    public interface ICountryLanguageService
    {
        Task<IEnumerable<CountryLanguage>> ListAsync();
        Task<IEnumerable<CountryLanguage>> ListByCountryIdAsync(int countryId);
        Task<IEnumerable<CountryLanguage>> ListByLanguageIdAsync(int languageId);
        Task<CountryLanguageResponse> AssignCountryLanguageAsync(int countryId, int languageId);
        Task<CountryLanguageResponse> UnassignCountryLanguageAsync(int countryId, int languageId);
    }
}
