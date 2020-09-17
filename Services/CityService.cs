using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Communications;

namespace GoingTo_API.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _cityRepository.ListAsync();
        }

        public async Task<CityResponse> GetByIdAsync(int id)
        {
            var existingCity = await _cityRepository.FindById(id);

            if (existingCity == null)
                return new CityResponse("City not found");
            return new CityResponse(existingCity);
        }

        public async Task<IEnumerable<City>> ListByCountryIdAsync(int countryId)
        {
            return await _cityRepository.ListByCountryIdAsync(countryId);
        }

        public async Task<CityResponse> GetByNameAsync(string name)
        {
            var existingCity = await _cityRepository.ListByNameAsync(name);

            if (existingCity == null)
                return new CityResponse("City not found");
            return new CityResponse(existingCity);

        }
    }
}
