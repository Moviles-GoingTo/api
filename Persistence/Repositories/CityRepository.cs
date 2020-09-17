using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(AppDbContext context ): base(context) { }

        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _context.Cities.Include(p=>p.Country.Locatable).Include(p=>p.Locatable).ToListAsync();
        }
        public async Task<City> FindById(int id)
        {
            return await _context.Cities
                .Where(p => p.Id == id)
                .Include(p => p.Locatable)
                .Include(p => p.Country.Locatable)
                .FirstAsync();
                
        }

        public async Task<IEnumerable<City>> ListByCountryIdAsync(int countryId) =>
            await _context.Cities
            .Where(p => p.CountryId == countryId)
            .Include(p => p.Locatable)
            .Include(p => p.Country.Locatable)
            .ToListAsync();

        public async Task<City> ListByNameAsync(string name) 
        {
            name = name.ToProperCase();

            return await _context.Cities
                .Where(p => p.Name == name)
                .Include(p=>p.Country)
                .Include(p=>p.Locatable)
                .FirstAsync();
        }
    }
}
