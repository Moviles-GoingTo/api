using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Geographic
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Currency>> ListAsync();
        Task<IEnumerable<Currency>> ListByCountryIdAsync(int countryId);
        Task<CurrencyResponse> GetByIdAsync(int id);
        Task<CurrencyResponse> SaveAsync(Currency currency);
        Task<CurrencyResponse> UpdateAsync(int id, Currency currency);
        Task<CurrencyResponse> DeleteAsync(int id);
    }
}
