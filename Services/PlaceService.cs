using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Geographic;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IPlaceCategoryRepository _placeCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlaceService(IPlaceRepository placeRepository, IUnitOfWork unitOfWork, IPlaceCategoryRepository placeCategoryRepository)
        {
            _unitOfWork = unitOfWork;
            _placeRepository = placeRepository;
            _placeCategoryRepository = placeCategoryRepository;

        }
        public async Task<PlaceResponse> DeleteAsync(int id)
        {
            var existingPlace = await _placeRepository.FindById(id);
            if (existingPlace == null)
                return new PlaceResponse("Place not found");
            try
            {
                _placeRepository.Remove(existingPlace);
                await _unitOfWork.CompleteAsync();

                return new PlaceResponse(existingPlace);
            }
            catch(Exception ex)
            {
                return new PlaceResponse($"An error ocurred while removing place: {ex.Message}");
            }
        }

        public async Task<PlaceResponse> GetByNameAsync(string name)
        {
            var existingPlace = await _placeRepository.FindByName(name);

            if (existingPlace == null)
                return new PlaceResponse("Country name not found");
            return new PlaceResponse(existingPlace);
        }

        public async Task<PlaceResponse> GetByIdAsync(int id)
        {
            var existingPlace = await _placeRepository.FindById(id);
            if (existingPlace == null)
                return new PlaceResponse("Place not found");
            return new PlaceResponse(existingPlace);
        }

        public async Task<IEnumerable<Place>> ListAsync()
        {
            return await _placeRepository.ListAsync();
        }

        public async Task<IEnumerable<Place>> ListByCategoryIdAsync(int categoryId)
        {
            var placeCategory = await _placeCategoryRepository.ListByCategoryIdAsync(categoryId);
            var places = placeCategory.Select(pt => pt.Place).ToList();
            return places;
        }

        public async Task<IEnumerable<Place>> ListByCityIdAsync(int cityId)
        {
            return await _placeRepository.ListByCityIdAsync(cityId);
        }

        public async Task<PlaceResponse> SaveAsync(Place place)
        {
            try
            {
                await _placeRepository.AddAsync(place);
                await _unitOfWork.CompleteAsync();

                return new PlaceResponse(place);
            }
            catch(Exception ex)
            {
                return new PlaceResponse($"An error ocurred while saving this place: {ex.Message}");
            }
        }

        public async Task<PlaceResponse> UpdateAsync(int id, Place place)
        {
            var existingPlace = await _placeRepository.FindById(id);
            if (existingPlace == null)
                return new PlaceResponse("Place not found");
            existingPlace.Name = place.Name;
            try
            {
                _placeRepository.Update(existingPlace);
                await _unitOfWork.CompleteAsync();

                return new PlaceResponse(existingPlace);
            }
            catch(Exception ex)
            {
                return new PlaceResponse($"An error ocurred while updating place: {ex.Message}");
            }
        }

    }
}
