using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;

namespace GoingTo_API.Domain.Repositories.Geographic
{
    public interface ITipRepository
    {
        Task<IEnumerable<Tip>> ListByLocatableIdAsync(int locatableId);
        Task <Tip> FindById(int tipId);
        Task AddAsync(Tip tip);
        void Update(Tip tip);
        void Remove(Tip tip);
    }
}
