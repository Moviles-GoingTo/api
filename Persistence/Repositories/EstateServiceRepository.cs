using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Models.Interactions;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class EstateServiceRepository : BaseRepository, IEstateServiceRepository
    {
        public EstateServiceRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(EstateService estateService)
        {
            await _context.EstateServices.AddAsync(estateService);
        }

        public async Task AssignEstateService(int estateId, int serviceId)
        {
            EstateService estateService = await FindByEstateIdAndServiceId(estateId, serviceId);
            if (estateService == null)
            {
                estateService = new EstateService { ServiceId = serviceId, EstateId = estateId };
                await AddAsync(estateService);
            }
        }

        public async Task<EstateService> FindByEstateIdAndServiceId(int estateId, int serviceId)
        {
            return await _context.EstateServices.FindAsync(estateId, serviceId);
        }

        public async Task<IEnumerable<EstateService>> ListAsync()
        {
            return await _context.EstateServices
                .Include(p => p.Estate)
                .Include(p => p.Service)
                .ToListAsync();
        }

        public async Task<IEnumerable<EstateService>> ListByEstateId(int estateId)
        {
            return await _context.EstateServices
                .Where(p => p.EstateId == estateId)
                .Include(p => p.Estate)
                .Include(p => p.Service)
                .ToListAsync();
        }

        public async Task<IEnumerable<EstateService>> ListByServiceId(int serviceId)
        {
            return await _context.EstateServices
                .Where(p => p.ServiceId == serviceId)
                .Include(p => p.Estate)
                .Include(p => p.Service)
                .ToListAsync();
        }

        public void Remove(EstateService estateService)
        {
            _context.EstateServices.Remove(estateService);
        }

        public async void UnassignEstateService(int estateId, int serviceId)
        {
            EstateService estateService = await FindByEstateIdAndServiceId(estateId, serviceId);
            if (estateService != null)
                Remove(estateService);

        }
    }
}
