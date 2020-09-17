using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Geographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Geographic
{
    public interface IPlaceCategoryRepository
    {
        Task<IEnumerable<PlaceCategory>> ListByPlaceIdAsync(int placeId);
        Task<IEnumerable<PlaceCategory>> ListByCategoryIdAsync(int categoryId);
        Task AssignPlaceCategory(int placeId, int categoryId);
        void UnassignPlaceCategory(int placeId, int categoryId);
        Task<PlaceCategory> FindByPlaceIdAndCategoryId(int placeId, int categoryId);
        Task AddAsync(PlaceCategory placeCategory);
        void Remove(PlaceCategory placeCategory);
    }
}
