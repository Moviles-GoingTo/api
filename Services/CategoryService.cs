using GoingTo_API.Domain.Models.Geographic;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Geographic;
using GoingTo_API.Domain.Services.Communications;
using GoingTo_API.Domain.Services.Geographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPlaceCategoryRepository _placeCategoryRepository;
        public readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IPlaceCategoryRepository placeCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _placeCategoryRepository = placeCategoryRepository;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> GetByIdAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindById(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found");
            return new CategoryResponse(existingCategory);
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error ocurred while saving the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindById(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found");

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error ocurred while updating category: {ex.Message}");
            }

        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindById(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found");

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error ocurred while deleting category: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> ListByPlaceIdAsync(int placeId)
        {
            var placeCategory = await _placeCategoryRepository.ListByPlaceIdAsync(placeId);
            var categories = placeCategory.Select(pt => pt.Category).ToList();
            return categories;
        }
    }
}
