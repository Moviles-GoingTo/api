using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Accounts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class PartnerRepository : BaseRepository, IPartnerRepository
    {
        public PartnerRepository(AppDbContext context) : base(context){}

        public async Task AddAsync(Partner partner)
        {
            await _context.Partners.AddAsync(partner);
        }

        public async Task<Partner> FindById(int id)
        {
            return await _context.Partners.FindAsync(id);
        }

        public async Task<IEnumerable<Partner>> ListAsync()
        {
            return await _context.Partners.ToListAsync();
        }

        public void Remove(Partner partner)
        {
            _context.Partners.Remove(partner);
        }

        public void Update(Partner partner)
        {
            _context.Partners.Update(partner);
        }
    }
}
