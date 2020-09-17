using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Geographic;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Geographic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class PlaceCategoryRepository : BaseRepository, IPlaceCategoryRepository
    {
        public PlaceCategoryRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(PlaceCategory placeCategory)
        {
            await _context.PlaceCategories.AddAsync(placeCategory);
        }

        public async Task AssignPlaceCategory(int placeId, int categoryId)
        {
            PlaceCategory placeCategory = await FindByPlaceIdAndCategoryId(placeId, categoryId);
            if (placeCategory == null)
            {
                placeCategory = new PlaceCategory { PlaceId = placeId, CategoryId = categoryId };
                await AddAsync(placeCategory);
            }
        }

        public async Task<PlaceCategory> FindByPlaceIdAndCategoryId(int placeId, int categoryId)
        {
            return await _context.PlaceCategories.FindAsync(categoryId, placeId);
        }

        public async Task<IEnumerable<PlaceCategory>> ListByCategoryIdAsync(int categoryId)
        {
            return await _context.PlaceCategories
                .Where(pt => pt.CategoryId == categoryId)
                .Include(pt => pt.Place)
                .Include(pt => pt.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<PlaceCategory>> ListByPlaceIdAsync(int placeId)
        {
            return await _context.PlaceCategories
                .Where(pt => pt.PlaceId == placeId)
                .Include(pt => pt.Place)
                .Include(pt => pt.Category)
                .ToListAsync();
        }

        public void Remove(PlaceCategory placeCategory)
        {
            _context.PlaceCategories.Remove(placeCategory);
        }

        public async void UnassignPlaceCategory(int placeId, int categoryId)
        {
            PlaceCategory placeCategory = await FindByPlaceIdAndCategoryId(placeId, categoryId);
            if (placeCategory != null)
            {
                Remove(placeCategory);
            }
        }
    }
}
