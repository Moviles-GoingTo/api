using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Geographic;
using GoingTo_API.Domain.Services.Communications;
using GoingTo_API.Domain.Services.Geographic;

namespace GoingTo_API.Services
{
    public class TipService : ITipService
    {
        private readonly ITipRepository _tipRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TipService(ITipRepository tipRepository, IUnitOfWork unitOfWork)
        {
            _tipRepository = tipRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Tip>> ListByLocatableIdAsync(int locatableId)
        {
            return await _tipRepository.ListByLocatableIdAsync(locatableId);
        }

        public async Task<TipResponse> GetByIdAsync(int id)
        {
            var existingTip = await _tipRepository.FindById(id);

            if (existingTip == null)
                return new TipResponse("Tip not found");
            return new TipResponse(existingTip);
        }

        public async Task<TipResponse> SaveAsync(Tip tip)
        {
            try
            {
                await _tipRepository.AddAsync(tip);
                await _unitOfWork.CompleteAsync();
                return new TipResponse(tip);
            }
            catch (Exception ex)
            {
                return new TipResponse($"An error ocurred while saving the Tip: {ex.Message}");
            }
        }
        public async Task<TipResponse> UpdateAsync(int tipId, Tip tip)
        {
            var existingTip = await _tipRepository.FindById(tipId);

            if (existingTip == null)
                return new TipResponse("Tip not found");
            existingTip.Text = tip.Text;

            try
            {
                _tipRepository.Update(existingTip);
                await _unitOfWork.CompleteAsync();

                return new TipResponse(existingTip);
            }
            catch (Exception ex)
            {
                return new TipResponse($"An error ocurred while updating the tip: {ex.Message}");
            }
        }
        public async Task<TipResponse> DeleteAsync(int tipId)
        {
            var existingTip = await _tipRepository.FindById(tipId);

            if (existingTip == null)
                return new TipResponse("Tip not found");

            try
            {
                _tipRepository.Remove(existingTip);
                await _unitOfWork.CompleteAsync();

                return new TipResponse(existingTip);
            }
            catch (Exception ex)
            {
                return new TipResponse($"An error ocurred while deleting Tip: {ex.Message}");
            }
        }
    }
}
