using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class PromoRepository : BaseRepository, IPromoRepository
    {
        public PromoRepository(AppDbContext context) : base(context) { }
       

        public async Task AddAsync(Promo promo)
        {
            await _context.Promos.AddAsync(promo);
        }

        public async Task<Promo> FindById(int id)
        {
            return await _context.Promos.FindAsync(id);
        }

        public async Task<IEnumerable<Promo>> FindByPartnerId(int partnerId)
        {
            return await _context.Promos
                .Where(p => p.PartnerId == partnerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Promo>> ListAsync()
        {
            return await _context.Promos.ToListAsync();
        }

        public void Remove(Promo promo)
        {
            _context.Promos.Remove(promo);
        }

        public void Update(Promo promo)
        {
            _context.Promos.Update(promo);
        }
    }
}
