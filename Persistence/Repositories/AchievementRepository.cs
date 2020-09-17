using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class AchievementRepository : BaseRepository, IAchievementRepository
    {
        public AchievementRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Achievement achievement)
        {
            await _context.Achievements.AddAsync(achievement);
        }

        public async Task<Achievement> FindById(int id)
        {
            return await _context.Achievements.FindAsync(id);
        }

        public async Task<IEnumerable<Achievement>> ListAsync()
        {
            return await _context.Achievements.ToListAsync();
        }

        public void Remove(Achievement achievement)
        {
            _context.Achievements.Remove(achievement);
        }

        public void Update(Achievement achievement)
        {
            _context.Achievements.Update(achievement);
        }
    }
}
