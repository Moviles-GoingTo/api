using GoingTo_API.Domain.Models.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Accounts
{
    public interface IWalletRepository
    {
        Task<IEnumerable<Wallet>> ListAsync();
        Task AddAsync(Wallet wallet);

        Task<Wallet> FindById(int id);
        void Update(Wallet wallet);

        void Remove(Wallet wallet);
    }
}
