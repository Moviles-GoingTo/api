using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class FavouriteRepository : BaseRepository, IFavouriteRepository
    {
        public FavouriteRepository(AppDbContext context) : base(context) { }
        
        public async Task AddAsync(Favourite favourite)
        {
            await _context.Favourites.AddAsync(favourite);
        }
        public async Task<Favourite> FindByUserIdAndLocatableId(int userId, int locatableId)
        {
            return await _context.Favourites.FindAsync(userId, locatableId);
        }

        public async Task<IEnumerable<Favourite>> ListAsync()
        {
            return await _context.Favourites.ToListAsync();
        }

        public void Remove(Favourite favourite)
        {
            _context.Favourites.Remove(favourite);
        }
        public async Task<IEnumerable<Favourite>> ListByUserIdAsync(int userId)
        {
            return await _context.Favourites
                 .Where(p => p.UserId == userId)
                 .Include(p => p.User)
                 .Include(p => p.Locatable)
                 .ToListAsync();
        }
        public async Task AssignFavourite(int userId, int locatableId)
        {
            Favourite favourite = await FindByUserIdAndLocatableId(userId, locatableId);
            if(favourite == null)
            {
                favourite = new Favourite { UserId = userId, LocatableId = locatableId };
                await AddAsync(favourite);
            }
        }
        public async Task UnassignFavourite(int userId, int locatableId)
        {
            Favourite favourite = await FindByUserIdAndLocatableId(userId, locatableId);
            if(favourite != null)
            {
                Remove(favourite);
            }
        }
    }
}
