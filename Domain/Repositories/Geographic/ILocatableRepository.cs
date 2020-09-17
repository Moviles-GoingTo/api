using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories
{
    public interface ILocatableRepository
    {
        Task<IEnumerable<Locatable>> ListAsync();
        Task<Locatable> FindById(int id);
        void Update(Locatable locatable);
        void Remove(Locatable locatable);
        Task AddAsync(Locatable locatable);
    }
}
