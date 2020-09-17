using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;

namespace GoingTo_API.Domain.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> ListAsync();
        Task<Country> FindById(int id);
        Task<Country> FindByFullName(string fullname);
        Task<Country> ListByLocatableIdAsync(int locatableId);
    }
}
