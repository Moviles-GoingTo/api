using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Business;
using Microsoft.EntityFrameworkCore;

namespace GoingTo_API.Persistence.Repositories
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public ServiceRepository(AppDbContext context): base(context) 
        {
        }

        public async Task<IEnumerable<Service>> ListAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> FindById(int serviceId)
        {
            return await _context.Services.FindAsync(serviceId);
        }
        public async Task AddAsync(Service service)
        {
            await _context.Services.AddAsync(service);
        }
        public void Update(Service service)
        {
            _context.Services.Update(service);
        }
        public void Remove(Service service)
        {
            _context.Services.Remove(service);
        }
    }
}
