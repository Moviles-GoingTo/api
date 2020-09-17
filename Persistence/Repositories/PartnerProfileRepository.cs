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
    public class PartnerProfileRepository : BaseRepository, IPartnerProfileRepository
    {
        public PartnerProfileRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(PartnerProfile partnerProfile)
        {
            await _context.PartnerProfiles.AddAsync(partnerProfile);
        }

        public async Task<PartnerProfile> FindById(int id)
        {
            return await _context.PartnerProfiles.FindAsync(id);
        }

        public async Task <PartnerProfile> FindByPartnerId(int partnerId)
        {
           return await _context.PartnerProfiles
                 .Where(p => p.PartnerId == partnerId)
                 .FirstAsync();
        }

        public void Remove(PartnerProfile partnerProfile)
        {
            _context.PartnerProfiles.Remove(partnerProfile);
        }

        public void Update(PartnerProfile partnerProfile)
        {
            _context.PartnerProfiles.Update(partnerProfile);
        }
    }
}
