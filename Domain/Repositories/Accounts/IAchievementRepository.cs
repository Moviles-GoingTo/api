using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Accounts;

namespace GoingTo_API.Domain.Repositories
{
    public interface IAchievementRepository
    {
        Task<IEnumerable<Achievement>> ListAsync();
        Task AddAsync(Achievement achievement);
        Task<Achievement> FindById(int id);
        void Update(Achievement achievement);
        void Remove(Achievement achievement);
    }
}
