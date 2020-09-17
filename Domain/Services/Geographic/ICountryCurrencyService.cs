using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Geographic
{
    public interface ICountryCurrencyService
    {
        Task<IEnumerable<CountryCurrency>> ListAsync();
        Task<IEnumerable<CountryCurrency>> ListByCountryIdAsync(int countryId);
        Task<IEnumerable<CountryCurrency>> ListByCurrencyIdAsync(int currencyId);
        Task<CountryCurrencyResponse> AssignCountryCurrencyAsync(int countryId, int currencyId);
        Task<CountryCurrencyResponse> UnassignCountryCurrencyAsync(int countryId, int currencyId);
    }
}
