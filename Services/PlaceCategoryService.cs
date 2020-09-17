using GoingTo_API.Domain.Models;
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
    public class PlaceCategoryService : IPlaceCategoryService
    {
        private readonly IPlaceCategoryRepository _placeCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PlaceCategoryService(IPlaceCategoryRepository placeCategoryRepository, IUnitOfWork unitOfWork)
        {
            _placeCategoryRepository = placeCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PlaceCategoryResponse> AssignPlaceCategoryAsync(int placeId, int categoryId)
        {
            try
            {

                await _placeCategoryRepository.AssignPlaceCategory(placeId, categoryId);
                await _unitOfWork.CompleteAsync();
                PlaceCategory placeCategory = await _placeCategoryRepository.FindByPlaceIdAndCategoryId(placeId, categoryId);
                return new PlaceCategoryResponse(placeCategory);
            }
            catch (Exception ex)
            {
                return new PlaceCategoryResponse($"An error ocurred while assigning Category to Place: {ex.Message}");
            }
        }

        public async Task<IEnumerable<PlaceCategory>> ListByCategoryIdAsync(int categoryId)
        {
            return await _placeCategoryRepository.ListByCategoryIdAsync(categoryId);
        }

        public async Task<IEnumerable<PlaceCategory>> ListByPlaceIdAsync(int placeId)
        {
            return await _placeCategoryRepository.ListByPlaceIdAsync(placeId);
        }

        public async Task<PlaceCategoryResponse> UnassignPlaceCategoryAsync(int placeId, int categoryId)
        {
            try
            {
                PlaceCategory placeCategory = await _placeCategoryRepository.FindByPlaceIdAndCategoryId(placeId, categoryId);
                _placeCategoryRepository.Remove(placeCategory);
                await _unitOfWork.CompleteAsync();
                return new PlaceCategoryResponse(placeCategory);
            }
            catch (Exception ex)
            {
                return new PlaceCategoryResponse($"An error ocurred while assigning Category to Place: {ex.Message}");
            }
        }
    }
}
