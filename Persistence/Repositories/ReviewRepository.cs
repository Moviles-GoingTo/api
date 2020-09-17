using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Interactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class ReviewRepository : BaseRepository, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Review review)
        {
           await _context.Reviews.AddAsync(review);
        }
        public void Remove(Review review)
        {
            _context.Reviews.Remove(review);
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }
        public async Task<Review> FindById(int id)
        {
            return await _context.Reviews
                .Where(p=>p.Id == id)
                .Include(p=>p.UserProfile)
                .FirstAsync();
        }

        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _context.Reviews.ToListAsync();
        }
        public async Task<IEnumerable<Review>> ListByLocatableIdAsync(int locatableId)
        {
            return await _context.Reviews
                .Where(p => p.LocatableId == locatableId)
                .Include(p => p.Locatable)
                .Include(p=>p.UserProfile)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> ListByUserProfileIdAsync(int userProfileId)
        {
            return await _context.Reviews
                .Where(p => p.UserProfileId == userProfileId)
                .Include(p=> p.UserProfile)
                .Include(p=>p.Locatable)
                .ToListAsync();
        }
    }
}
