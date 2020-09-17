using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Accounts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users
                .Include(p=> p.Wallet)
                .ToListAsync();
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
