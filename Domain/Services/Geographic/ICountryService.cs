using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;

namespace GoingTo_API.Domain.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> ListAsync();
        Task<CountryResponse> GetByFullNameAsync(string fullname);
        Task<CountryResponse> GetByIdAsync(int id);
        Task<IEnumerable<Country>> ListByCurrencyIdAsync(int currencyId);
        Task<IEnumerable<Country>> ListByLanguageIdAsync(int languageId);
    }
}
