using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;

namespace GoingTo_API.Domain.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> ListAsync();
        Task<IEnumerable<City>> ListByCountryIdAsync(int countryId);
        Task<CityResponse> GetByIdAsync(int id);
        Task<CityResponse> GetByNameAsync(string name);
    }
}
