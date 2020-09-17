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
    public class BenefitRepository : BaseRepository, IBenefitRepository
    {
        public BenefitRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Benefit benefit)
        {
            await _context.Benefits.AddAsync(benefit);
        }

        public async Task<Benefit> FindById(int id)
        {
           return await _context.Benefits.FindAsync(id);
        }

        public async Task<IEnumerable<Benefit>> ListAsync()
        {
            return await _context.Benefits.ToListAsync();
        }

        public void Remove(Benefit benefit)
        {
            _context.Benefits.Remove(benefit);
        }

        public void Update(Benefit benefit)
        {
            _context.Benefits.Update(benefit);
        }
    }
}
