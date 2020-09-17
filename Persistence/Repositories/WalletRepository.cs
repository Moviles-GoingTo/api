using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class WalletRepository : BaseRepository, IWalletRepository
    {
        public WalletRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
        }

        public async Task<IEnumerable<Wallet>> ListAsync()
        {
            return await _context.Wallets.ToListAsync();
        }

        public async Task<Wallet> FindById(int id)
        {
            return await _context.Wallets.FindAsync(id);
        }

        public void Update(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
        }

        public void Remove(Wallet wallet)
        {
            _context.Wallets.Remove(wallet);
        }
    }
}
