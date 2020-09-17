using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Geographic;
using Microsoft.EntityFrameworkCore;

namespace GoingTo_API.Persistence.Repositories
{
    public class TipRepository : BaseRepository, ITipRepository
    {
        public TipRepository(AppDbContext context): base(context)
        {
        }
        public async Task<IEnumerable<Tip>> ListByLocatableIdAsync(int locatableId)
        {
            return await _context.Tips
                .Where(p => p.LocatableId == locatableId)
                .Include(p => p.Locatable)
                .ToListAsync();
        }
        public async Task<Tip> FindById(int tipId)
        {
            return await _context.Tips.FindAsync(tipId);
        }

        public async Task AddAsync(Tip tip)
        {
            await _context.Tips.AddAsync(tip);
        }

        public void Update(Tip tip)
        {
            _context.Tips.Update(tip);
        }
        public void Remove(Tip tip)
        {
            _context.Tips.Remove(tip);
        }
    }
}
