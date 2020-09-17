using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Accounts;
using GoingTo_API.Domain.Services.Accounts;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WalletService(IWalletRepository walletRepository, IUnitOfWork unitOfWork)
        {
            _walletRepository = walletRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Wallet>> ListAsync()
        {
            return await _walletRepository.ListAsync();
        }

        public async Task<WalletResponse> SaveAsync(Wallet wallet)
        {
            try
            {
                await _walletRepository.AddAsync(wallet);
                await _unitOfWork.CompleteAsync();

                return new WalletResponse(wallet);
            }

            catch (Exception ex)
            {
                return new WalletResponse($"An error ocurred while saving wallet: {ex.Message}");
            }
        }

        public async Task<WalletResponse> UpdateAsync(int id, Wallet wallet)
        {
            var existingWallet = await _walletRepository.FindById(id);

            if (existingWallet == null)
                return new WalletResponse("Wallet not found");

            existingWallet.Points = wallet.Points;

            try
            {
                _walletRepository.Update(existingWallet);
                await _unitOfWork.CompleteAsync();

                return new WalletResponse(existingWallet);
            }

            catch (Exception ex)
            {
                return new WalletResponse($"An error ocurred while updating wallet : {ex.Message}");
            }
        }

        public async Task<WalletResponse> DeleteAsync(int id)
        {
            var existingWallet = await _walletRepository.FindById(id);

            if (existingWallet == null)
                return new WalletResponse("Wallet not found");

            try
            {
                _walletRepository.Remove(existingWallet);
                await _unitOfWork.CompleteAsync();
                return new WalletResponse(existingWallet);
            }

            catch (Exception ex)
            {
                return new WalletResponse($"An error ocurred while deleting wallet : {ex.Message}");
            }
        }
    }
}
