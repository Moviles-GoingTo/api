using GoingTo_API.Domain.Models.Geographic;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Geographic
{
    public interface IPlaceCategoryService
    {
        Task<IEnumerable<PlaceCategory>> ListByPlaceIdAsync(int placeId);
        Task<IEnumerable<PlaceCategory>> ListByCategoryIdAsync(int categoryId);
        Task<PlaceCategoryResponse> AssignPlaceCategoryAsync(int placeId, int categoryId);
        Task<PlaceCategoryResponse> UnassignPlaceCategoryAsync(int placeId, int categoryId);
    }
}
