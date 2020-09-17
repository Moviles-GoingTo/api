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
    public class FavouriteService : IFavouriteService
    {
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FavouriteService(IFavouriteRepository favouriteRepository, IUnitOfWork unitOfWork)
        {
            _favouriteRepository = favouriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Favourite>> ListAsync()
        {
            return await _favouriteRepository.ListAsync();
        }

        public async Task<IEnumerable<Favourite>> ListByUserIdAsync(int userId)
        {
            return await _favouriteRepository.ListByUserIdAsync(userId);
        }
        public async Task<FavouriteResponse> AssignFavouriteAsync(int userId, int locatableId)
        {
            try
            {
                await _favouriteRepository.AssignFavourite(userId, locatableId);
                await _unitOfWork.CompleteAsync();
                Favourite favourite = await _favouriteRepository.FindByUserIdAndLocatableId(userId, locatableId);
                return new FavouriteResponse(favourite);
            }
            catch(Exception ex)
            {
                return new FavouriteResponse($"An error ocurred while assigning Favourite to User: {ex.Message}");
            }
        }
        public async Task<FavouriteResponse> UnassignFavouriteAsync(int userId, int locatableId)
        {
            try
            {
                Favourite favourite = await _favouriteRepository.FindByUserIdAndLocatableId(userId, locatableId);
                _favouriteRepository.Remove(favourite);
                await _unitOfWork.CompleteAsync();
                return new FavouriteResponse(favourite);
            }
            catch(Exception ex)
            {
                return new FavouriteResponse($"An error ocurred while unnasigning Favourite to User: {ex.Message}");
            }
        }
    }
}
