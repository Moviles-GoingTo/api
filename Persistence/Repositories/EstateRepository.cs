using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Business;
using GoingTo_API.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class EstateRepository : BaseRepository, IEstateRepository
    {
        public EstateRepository(AppDbContext context) : base(context) { }
       
        public async Task AddAsync(Estate estate)
        {
            await _context.Estates.AddAsync(estate);
        }

        public async Task<Estate> FindById(int id)
        {
            return await _context.Estates.FindAsync(id);
        }

        

        public async Task<IEnumerable<Estate>> ListAsync()
        {
            return await _context.Estates.ToListAsync();
        }

        public async Task<IEnumerable<Estate>> ListByPartnerNameAsync(string partnerName)
        {
            partnerName = partnerName.ToProperCase();
            return await _context.Estates
                .Where(p => p.Partner.Name == partnerName)
                .ToListAsync();
        }

        public void Remove(Estate estate)
        {
            _context.Estates.Remove(estate);
        }

        public void Update(Estate estate)
        {
            _context.Estates.Update(estate);
        }
    }
}
