using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Geographic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class CurrencyRepository : BaseRepository, ICurrencyRepository
    {
        public CurrencyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Currency currency)
        {
           await _context.Currencies.AddAsync(currency);
        }

        public async Task<Currency> FindById(int id)
        {
            return await _context.Currencies.FindAsync(id);
        }

        public async Task<IEnumerable<Currency>> ListAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public void Remove(Currency currency)
        {
            _context.Currencies.Remove(currency);
        }

        public void Update(Currency currency)
        {
            _context.Currencies.Update(currency);
        }
    }
}
