using GoingTo_API.Domain.Models.Geographic;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Geographic
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> GetByIdAsync(int id);
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);
        Task<IEnumerable<Category>> ListByPlaceIdAsync(int placeId);
    }
}
