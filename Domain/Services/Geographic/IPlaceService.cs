using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services
{
    public interface IPlaceService
    {
        Task<IEnumerable<Place>> ListAsync();
        Task<IEnumerable<Place>> ListByCityIdAsync(int cityId); 
        Task<PlaceResponse> GetByIdAsync(int id);
        Task<PlaceResponse> GetByNameAsync(string name);
        Task<PlaceResponse> SaveAsync(Place place);
        Task<PlaceResponse> UpdateAsync(int id, Place place);
        Task<PlaceResponse> DeleteAsync(int id);
        Task<IEnumerable<Place>> ListByCategoryIdAsync(int categoryId);
    }
}
