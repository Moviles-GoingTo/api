using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Business;
using Microsoft.EntityFrameworkCore;

namespace GoingTo_API.Persistence.Repositories
{
    public class LocatablePromoRepository : BaseRepository, ILocatablePromoRepository
    {
        public LocatablePromoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(LocatablePromo locatablePromo)
        {
            await _context.LocatablePromos.AddAsync(locatablePromo);
        }

        public async Task AssignLocatablePromo(int locatableId, int promoId)
        {
            LocatablePromo locatablePromo = await FindByLocatableIdAndPromoId(locatableId, promoId);
            if(locatablePromo==null)
            {
                locatablePromo = new LocatablePromo { LocatableId = locatableId, PromoId = promoId };
                await AddAsync(locatablePromo);
            }
        }

        public async Task<LocatablePromo> FindByLocatableIdAndPromoId(int locatableId, int promoId)
        {
            return await _context.LocatablePromos.FindAsync(locatableId, promoId);
        }

        public async Task<IEnumerable<LocatablePromo>> ListAsync()
        {
            return await _context.LocatablePromos
                .Include(p=>p.Promo)
                .Include(p=>p.Locatable)
                .ToListAsync();
        }

        public async Task<IEnumerable<LocatablePromo>> ListByLocatableIdAsync(int locatableId)
        {
            return await _context.LocatablePromos
                .Where(p=>p.LocatableId==locatableId)
                .Include(p => p.Promo)
                .Include(p => p.Locatable)
                .ToListAsync();
        }

        public async Task<IEnumerable<LocatablePromo>> ListByPromoIdAsync(int promoId)
        {
            return await _context.LocatablePromos
                .Where(p => p.PromoId == promoId)
                .Include(p => p.Promo)
                .Include(p => p.Locatable)
                .ToListAsync();
        }

        public void Remove(LocatablePromo locatablePromo)
        {
            _context.Remove(locatablePromo);
        }

        public async void UnassignLocatablePromoAsync(int locatableId, int promoId)
        {
            LocatablePromo locatablePromo = await FindByLocatableIdAndPromoId(locatableId, promoId);
            if(locatablePromo==null)
            {
                Remove(locatablePromo);
            }
        }
    }
}
