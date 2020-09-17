using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Services.Communications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Accounts
{
    public interface IWalletService
    {
        Task<IEnumerable<Wallet>> ListAsync();
        Task<WalletResponse> SaveAsync(Wallet wallet);
        Task<WalletResponse> UpdateAsync(int id, Wallet wallet);
        Task<WalletResponse> DeleteAsync(int id);
    }
}
