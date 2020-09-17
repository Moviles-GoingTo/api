using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;

namespace GoingTo_API.Domain.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> ListAsync();
        Task<IEnumerable<City>> ListByCountryIdAsync(int countryId);
        Task<City> ListByNameAsync(string name);
        Task<City> FindById(int id);
    }
}
