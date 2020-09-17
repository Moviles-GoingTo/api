using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class LocatableService : ILocatableService
    {
        private readonly ILocatableRepository _locatableRepository;
        private readonly IFavouriteRepository _favouriteRepository;
        public readonly IUnitOfWork _unitOfWork;

        public LocatableService(ILocatableRepository locatableRepository,IUnitOfWork unitOfWork, IFavouriteRepository favouriteRepository)
        {
            _locatableRepository = locatableRepository;
            _unitOfWork = unitOfWork;
            _favouriteRepository = favouriteRepository;
        }

        public async Task<IEnumerable<Locatable>> ListAsync()
        {
            return await _locatableRepository.ListAsync();
        }

        public async Task<LocatableResponse> SaveAsync(Locatable locatable)
        {
            try
            {
                await _locatableRepository.AddAsync(locatable);
                await _unitOfWork.CompleteAsync();
                return new LocatableResponse(locatable);
            }
            catch(Exception ex)
            {
                return new LocatableResponse($"An error ocurred while saving the locatable: {ex.Message}");
            }
        }

        public async Task<LocatableResponse> UpdateAsync(int id, Locatable locatable)
        {
            var existingLocatable = await _locatableRepository.FindById(id);
            if (existingLocatable == null)
                return new LocatableResponse("Locatable not found");
            existingLocatable.Id = locatable.Id;
            try
            {
                _locatableRepository.Update(existingLocatable);
                await _unitOfWork.CompleteAsync();

                return new LocatableResponse(existingLocatable);
            }
            catch(Exception ex)
            {
                return new LocatableResponse($"An error ocurred while updating the locatable: {ex.Message}");
            }
        }

        public async Task<LocatableResponse> DeleteAsync(int id)
        {
            var existingLocatable = await _locatableRepository.FindById(id);
            if (existingLocatable == null)
                return new LocatableResponse("Locatable not found");
            try
            {
                _locatableRepository.Remove(existingLocatable);
                await _unitOfWork.CompleteAsync();
                return new LocatableResponse(existingLocatable);
            }
            catch(Exception ex)
            {
                return new LocatableResponse($"An error ocurred while removing category: {ex.Message}");
            }
        }

        public async Task<LocatableResponse> GetByIdAsync(int id)
        {
            var existingLocatable = await _locatableRepository.FindById(id);
            if (existingLocatable == null)
                return new LocatableResponse("Locatable not found");
            return new LocatableResponse(existingLocatable);
        }

        public async Task<IEnumerable<Locatable>> ListByUserIdAsync(int userId)
        {
            var userIds = await _favouriteRepository.ListByUserIdAsync(userId);
            var locatables = userIds.Select(p => p.Locatable).ToList();
            return locatables;
        }

    }
}
